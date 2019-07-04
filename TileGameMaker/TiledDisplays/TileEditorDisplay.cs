﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameLib.Components;

namespace TileGameMaker.TiledDisplays
{
    public class TileEditorDisplay : TiledDisplay
    {
        private Tileset Tileset;
        private int TileIndex;

        public TileEditorDisplay(Control parent, int cols, int rows, int zoom)
            : base(parent, cols, rows, zoom)
        {
            Graphics.Palette.Set(0, Color.White);
            Graphics.Palette.Set(1, Color.Black);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Tileset == null || (TileIndex < 0 || TileIndex >= Tileset.Size))
            {
                base.OnPaint(e);
                return;
            }

            string pixels = Tileset.Get(TileIndex).ToString();
            int pix = 0;

            for (int y = 0; y < Graphics.Rows; y++)
            {
                for (int x = 0; x < Graphics.Cols; x++)
                {
                    if (pixels[pix] == '0')
                        Graphics.PutTile(x, y, 0xdb, 0, 1);
                    else if (pixels[pix] == '1')
                        Graphics.PutTile(x, y, 0xdb, 1, 0);

                    pix++;
                }
            }

            base.OnPaint(e);
        }

        public void SetTile(Tileset tileset, int index)
        {
            Tileset = tileset;
            TileIndex = index;
        }

        public void SetTilePixel(int x, int y, int pixel)
        {
            if (x < 0 || y < 0 || x >= TilePixels.RowLength || y >= TilePixels.RowCount)
                return;

            byte row = Tileset.Get(TileIndex).PixelRows[y];

            if (pixel > 0)
                row = row.SetBit(x);
            else
                row = row.UnsetBit(x);
            
            Tileset.Get(TileIndex).PixelRows[y] = row;
            Refresh();
        }

        public void SetTilePixels(TilePixels pixels)
        {
            Tileset.Get(TileIndex).SetEqual(pixels);
            Refresh();
        }

        public void ClearTile()
        {
            Tileset.Get(TileIndex).Clear();
            Refresh();
        }

        public void InvertTile()
        {
            Tileset.Get(TileIndex).Invert();
            Refresh();
        }

        public void FlipHorizontal()
        {
            Tileset.Get(TileIndex).FlipHorizontal();
            Refresh();
        }

        public void FlipVertical()
        {
            Tileset.Get(TileIndex).FlipVertical();
            Refresh();
        }

        public void RotateRight()
        {
            Tileset.Get(TileIndex).RotateRight();
            Refresh();
        }

        public void RotateLeft()
        {
            Tileset.Get(TileIndex).RotateLeft();
            Refresh();
        }

        public void RotateUp()
        {
            Tileset.Get(TileIndex).RotateUp();
            Refresh();
        }

        public void RotateDown()
        {
            Tileset.Get(TileIndex).RotateDown();
            Refresh();
        }
    }
}
