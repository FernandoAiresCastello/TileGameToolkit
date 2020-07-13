﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Exceptions;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.Engine
{
    public class GameEngine
    {
        public string MapsPath { set; get; }
        public bool Paused { set; get; }
        public GameWindow Window { get; protected set; }
        public DebuggerWindow Debugger { get; protected set; }
        public long Cycle { get; protected set; }

        protected bool Running = false;
        protected MapController MapController;
        protected MapController PreviousMapController;
        protected readonly MapControllerCollection MapControllers;
        protected MapRenderer MapRenderer;
        protected ObjectMap Overlay;
        protected MapRenderer OverlayRenderer;

        private readonly Timer CycleTimer;
        private readonly SoundPlayer BgmPlayer;
        private readonly SoundPlayer SfxPlayer;

        public GameEngine()
        {
            MapControllers = new MapControllerCollection();
            BgmPlayer = new SoundPlayer();
            SfxPlayer = new SoundPlayer();
            Debugger = new DebuggerWindow(this);

            CycleTimer = new Timer();
            CycleTimer.Interval = 1;
            CycleTimer.Tick += CycleTimer_Tick;
        }

        public GameEngine(string winTitle, int winCols, int winRows, int zoom, int cycleInterval, string mapsPath = null) :
            this(winTitle, winCols, winRows, zoom, cycleInterval, true, true, mapsPath)
        {
        }

        public GameEngine(string winTitle, int winCols, int winRows, int zoom, int cycleInterval,
            bool allowFullscreenWindow, bool allowResizeWindow, string mapsPath = null)
        {
            MapsPath = mapsPath;
            Window = new GameWindow(this, winTitle, winCols, winRows, zoom, allowFullscreenWindow, allowResizeWindow);
            MapControllers = new MapControllerCollection();
            BgmPlayer = new SoundPlayer();
            SfxPlayer = new SoundPlayer();
            Debugger = new DebuggerWindow(this);

            MapRenderer = new MapRenderer(Window.Display);
            MapRenderer.Viewport = new Rectangle(0, 0, Window.Display.Cols, Window.Display.Rows);

            OverlayRenderer = new MapRenderer(Window.Display);
            OverlayRenderer.Viewport = new Rectangle(0, 0, Window.Display.Cols, Window.Display.Rows);
            OverlayRenderer.ClearViewportBeforeRender = false;

            CycleTimer = new Timer();
            CycleTimer.Interval = cycleInterval;
            CycleTimer.Tick += CycleTimer_Tick;
        }

        public void Run()
        {
            Run(null);
        }

        public void Run(Form parent)
        {
            Running = true;
            OnStart();
            Cycle = 0;
            CycleTimer.Start();

            if (parent == null)
                Application.Run(Window);
            else
                Window.ShowDialog(parent);
        }

        public void Stop()
        {
            Running = false;
            CycleTimer.Stop();
        }

        public void Exit()
        {
            Stop();

            if (Window != null)
                Window.Close();
            
            Application.Exit();
        }

        public virtual void OnStart()
        {
            // Override this to initialize the engine
            // Called once immediately before the engine starts running
        }

        public virtual void OnExecuteCycle()
        {
            // Override this to globally do stuff on every cycle
            // Called whenever the cycle timer interval elapses
        }

        public virtual bool OnKeyDown(KeyEventArgs e)
        {
            // Override this to globally do stuff whenever some key is pressed down
            // Return true if the keydown event was handled, false otherwise
            // If this is handled, the event won't be sent to the map controller

            return false;
        }

        public virtual bool OnKeyUp(KeyEventArgs e)
        {
            // Override this to globally do stuff whenever some key is released
            // Return true if the keyup event was handled, false otherwise
            // If this is handled, the event won't be sent to the map controller

            return false;
        }

        public virtual bool OnMapTransition(MapController currentController, MapController nextController)
        {
            // Override this to do stuff whenever there is a transition from one map to another
            // Return false to cancel the transition, true otherwise

            return true;
        }

        public void Log(object obj)
        {
            Debug.WriteLine(obj);
        }

        public void HandleKeyDownEvent(KeyEventArgs e)
        {
            bool global = OnKeyDown(e);
            if (!global && !Paused && MapController != null)
                MapController.OnKeyDown(e);
        }

        public void HandleKeyUpEvent(KeyEventArgs e)
        {
            bool global = OnKeyUp(e);
            if (!global && !Paused && MapController != null)
                MapController.OnKeyUp(e);
        }

        public void PlaySoundEffect(string soundFile)
        {
            SfxPlayer.SoundLocation = soundFile;
            SfxPlayer.Play();
        }

        public void PlayMusicOnce(string musicFile)
        {
            StopMusic();
            BgmPlayer.SoundLocation = musicFile;
            BgmPlayer.Play();
        }

        public void PlayMusicLoop(string musicFile)
        {
            StopMusic();
            BgmPlayer.SoundLocation = musicFile;
            BgmPlayer.PlayLooping();
        }

        public void AwaitPlayMusic(string musicFile)
        {
            StopMusic();
            BgmPlayer.SoundLocation = musicFile;
            BgmPlayer.PlaySync();
        }

        public void StopMusic()
        {
            BgmPlayer.Stop();
        }

        protected string GetMapPath(string mapFile)
        {
            if (string.IsNullOrWhiteSpace(MapsPath))
                return mapFile;

            string basePath = MapsPath.Replace('\\', '/');
            string mapPath = "";

            if (string.IsNullOrWhiteSpace(basePath))
            {
                mapPath = mapFile;
            }
            else
            {
                if (basePath.EndsWith("/"))
                    mapPath = basePath + mapFile;
                else
                    mapPath = basePath + "/" + mapFile;
            }

            return mapPath;
        }

        public void LoadOverlay(string mapFile)
        {
            if (!System.IO.File.Exists(mapFile))
                throw new TGLException($"Overlay map file not found: {mapFile}");

            Overlay = MapFile.LoadFromRawBytes(mapFile);
            OverlayRenderer.Map = Overlay;
        }

        public void SetOverlay(ObjectMap overlayMap)
        {
            Overlay = overlayMap;
            OverlayRenderer.Map = Overlay;
        }

        public ObjectMap LoadMap(string mapFile, MapController controller)
        {
            ObjectMap map = MapControllers.AddController(GetMapPath(mapFile), controller);
            controller.OnLoad();
            return map;
        }

        public void AddMap(ObjectMap map, MapController controller)
        {
            MapControllers.AddController(map, controller);
            MapRenderer.Map = map;
            controller.OnLoad();
        }

        public void EnterMap(ObjectMap map)
        {
            EnterMapById(map.Id);
        }

        public void EnterMapByName(string mapName)
        {
            MapController controller = MapControllers.FindByName(mapName);
            if (controller == null)
                throw new TGLException($"Map with name {mapName} not found");

            EnterMapById(controller.Map.Id);
        }

        public void EnterMapById(string mapId)
        {
            MapController controller = MapControllers.FindById(mapId);
            if (controller == null)
                throw new TGLException($"Map with id {mapId} not found");

            bool transitionNotCancelled = OnMapTransition(MapController, controller);

            if (transitionNotCancelled)
            {
                if (MapController != null)
                    MapController.OnLeave();

                SetMapController(controller);
                MapController.OnEnter();
            }

            MapRenderer.Map = controller.Map;
        }

        public void EnterPreviousMap()
        {
            if (PreviousMapController != null)
                EnterMap(PreviousMapController.Map);
        }

        public void ReloadMap(string mapId)
        {
            MapController controller = MapControllers.FindById(mapId);
            controller.Map.SetEqual(MapFile.LoadFromRawBytes(GetMapPath(controller.MapFile)));
            SetMapController(controller);
            controller.OnLoad();
            EnterMap(controller.Map);
        }

        public void ReloadCurrentMap()
        {
            ReloadMap(MapController.Map.Id);
        }

        private void SetMapController(MapController controller)
        {
            PreviousMapController = MapController;
            MapController = controller;
            MapController.Engine = this;
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            if (!Paused)
            {
                OnExecuteCycle();
                if (MapController != null)
                    MapController.OnExecuteCycle();

                Cycle++;
            }
        }

        public void ShowDebugWindow()
        {
            Debugger.Show();
        }

        public void SetWindowSize(int width, int height)
        {
            Window.Size = new Size(width, height);
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            MapRenderer.Viewport = new Rectangle(x, y, width, height);
        }

        public void ScrollMapByDistance(int dx, int dy)
        {
            MapRenderer.ScrollByDistance(dx, dy);
        }

        public void ScrollMapToCenter(ObjectPosition pos)
        {
            MapRenderer.ScrollToCenter(pos.Point);
        }
    }
}
