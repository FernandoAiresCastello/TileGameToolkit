﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameRunner
{
    public class GameWindow : DisplayWindow
    {
        public GameWindow(int cols, int rows) : base(cols, rows)
        {
        }

        protected override void HandleMouseEvent(MouseEventArgs e)
        {
            // Nothing to do
        }

        protected override void HandleKeyEvent(KeyEventArgs e)
        {
        }
    }
}
