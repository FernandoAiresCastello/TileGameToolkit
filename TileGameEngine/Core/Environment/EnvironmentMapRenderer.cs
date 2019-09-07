﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        private MapRenderer MapRenderer;

        public void SetMapViewX(int x)
        {
            if (MapRenderer == null)
                StartMapRenderer();

            Rectangle view = MapRenderer.Viewport;
            MapRenderer.Viewport = new Rectangle(x, view.Y, view.Width, view.Height);
        }

        public void SetMapViewY(int y)
        {
            if (MapRenderer == null)
                StartMapRenderer();

            Rectangle view = MapRenderer.Viewport;
            MapRenderer.Viewport = new Rectangle(view.X, y, view.Width, view.Height);
        }

        public void SetMapViewWidth(int width)
        {
            if (MapRenderer == null)
                StartMapRenderer();

            Rectangle view = MapRenderer.Viewport;
            MapRenderer.Viewport = new Rectangle(view.X, view.Y, width, view.Height);
        }

        public void SetMapViewHeight(int height)
        {
            if (MapRenderer == null)
                StartMapRenderer();

            Rectangle view = MapRenderer.Viewport;
            MapRenderer.Viewport = new Rectangle(view.X, view.Y, view.Width, height);
        }

        public void SetMapViewScrollX(int scrollX)
        {
            if (MapRenderer == null)
                StartMapRenderer();

            Point currentScroll = MapRenderer.Scroll;
            MapRenderer.Scroll = new Point(scrollX, currentScroll.Y);
        }

        public void SetMapViewScrollY(int scrollY)
        {
            if (MapRenderer == null)
                StartMapRenderer();

            Point currentScroll = MapRenderer.Scroll;
            MapRenderer.Scroll = new Point(currentScroll.X, scrollY);
        }

        public void StartMapRenderer()
        {
            AssertWindowIsOpen();

            if (MapRenderer == null)
                MapRenderer = new MapRenderer(Map, Window.Display, new Rectangle(0, 0, 0, 0), new Point(0, 0));

            MapRenderer.AutoRefresh = true;
        }

        public void StopMapRenderer()
        {
            AssertWindowIsOpen();

            if (MapRenderer != null)
            {
                MapRenderer.AutoRefresh = false;
                RefreshWindow();
            }
        }
    }
}