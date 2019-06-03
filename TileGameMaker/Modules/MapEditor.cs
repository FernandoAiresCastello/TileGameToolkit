﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Graphics;
using TileGameMaker.Component;

namespace TileGameMaker.Modules
{
    public class MapEditor : Module
    {
        public ObjectMap Map { get; private set; }
        public MapWindow MapWindow { get; private set; }
        public TilePickerWindow TilePickerWindow { get; private set; }
        public ColorPickerWindow ColorPickerWindow { get; private set; }

        private readonly Form Parent;

        public MapEditor(Form parent)
        {
            Parent = parent;
            Map = new ObjectMap(31, 21);
            MapWindow = new MapWindow(this, Map);
            TilePickerWindow = new TilePickerWindow(this, Map.Charset);
            ColorPickerWindow = new ColorPickerWindow(this, Map.Palette);

            if (parent.IsMdiContainer)
            {
                MapWindow.MdiParent = parent;
                TilePickerWindow.MdiParent = parent;
                ColorPickerWindow.MdiParent = parent;
            }
        }

        public void Show()
        {
            MapWindow.Show();
            TilePickerWindow.Show();
            ColorPickerWindow.Show();
        }

        public Tile GetSelectedTile()
        {
            return new Tile(
                TilePickerWindow.GetTileIndex(),
                ColorPickerWindow.GetForeColorIndex(), 
                ColorPickerWindow.GetBackColorIndex());
        }
    }
}
