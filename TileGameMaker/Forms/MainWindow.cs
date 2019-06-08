﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameMaker.Modules;
using TileGameMaker.Component;

namespace TileGameMaker.Forms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            MapEditor editor = new MapEditor(this);
            editor.MapWindow.Location = new Point(0, 0);
            editor.ColorPickerWindow.Location = new Point(800, 0);
            editor.TilePickerWindow.Location = new Point(1050, 0);
            editor.TemplateWindow.Location = new Point(800, 370);
            editor.Show();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
