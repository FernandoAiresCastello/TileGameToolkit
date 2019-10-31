﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class MapController
    {
        public GameEngine Engine { set; get; }
        public GameWindow Window { set; get; }
        public ObjectMap Map { set; get; }
        public string MapFile { set; get; }

        public MapController()
        {
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnLeave()
        {
        }

        public virtual void OnExecuteCycle()
        {
        }

        public virtual void OnKeyDown(KeyEventArgs e)
        {
        }

        public virtual void OnKeyUp(KeyEventArgs e)
        {
        }

        public void Log(object obj)
        {
            Engine.Log(obj);
        }

        public void EnterMap(string mapName)
        {
            Engine.EnterMap(mapName);
        }

        public void PrintUi(string placeholderObjectTag, string text)
        {
            Engine.PrintUi(placeholderObjectTag, text);
        }
    }
}
