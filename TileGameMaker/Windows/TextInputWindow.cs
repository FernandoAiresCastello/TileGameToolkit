﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Windows
{
    public partial class TextInputWindow : Form
    {
        public new string Text { get; private set; }
        public string TextOrientation => (string)CmbOrientation.SelectedItem;

        public TextInputWindow() : this("")
        {
        }

        public TextInputWindow(string title)
        {
            InitializeComponent();
            base.Text = title;
            CmbOrientation.SelectedIndex = 0;
        }

        public DialogResult ShowDialog(Control parent, string text)
        {
            Text = text;
            TxtText.Text = text;
            TxtText.Select(0, 0);
            return ShowDialog(parent);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Text = TxtText.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
