﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.Modules;
using TileGameLib.Core;
using TileGameLib.Graphics;
using TileGameMaker.TiledDisplays;
using TileGameMaker.Windows;

namespace TileGameMaker.Panels
{
    public partial class TemplatePanel : BasePanel
    {
        public GameObject Object { set; get; }
        public AnimationStripDisplay AnimationStrip { set; get; }
        public ObjectAnim Animation => AnimationStrip.Animation;
        public ObjectAnim CroppedAnimation => AnimationStrip.Animation.CopyFrames(AnimationFrameCount);

        public int AnimationFrameCount
        {
            get
            {
                int.TryParse(TxtFrames.Text, out int frames);
                return frames;
            }

            set
            {
                TxtFrames.Text = value.ToString();
                Refresh();
            }
        }

        private MapEditor MapEditor;
        private readonly int MaxFrames = 8;

        public TemplatePanel()
        {
            InitializeComponent();
        }

        public TemplatePanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
            Object = new GameObject();
            AnimationStrip = new AnimationStripDisplay(AnimationPanel, MaxFrames, 1, 3);
            AnimationStrip.Graphics.Tileset = editor.Map.Tileset;
            AnimationStrip.Graphics.Palette = editor.Map.Palette;
            AnimationStrip.MouseDown += AnimationStrip_MouseDown;
            TxtFrames.Text = 1.ToString();
        }

        private void TemplateControl_Shown(object sender, EventArgs e)
        {
            Refresh();
        }

        public override void Refresh()
        {
            base.Refresh();
            TxtType.Text = Object.Type.ToString();
            TxtParam.Text = Object.Param.ToString();
            TxtData.Text = Object.Data;
            LblTypeHex.Text = "0x" + Object.Type.ToString("X2");
            LblParamHex.Text = "0x" + Object.Param.ToString("X2");
        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtType.Text, out int type);
            int.TryParse(TxtParam.Text, out int param);

            if (type < 0)
                type = 0;
            else if (type > byte.MaxValue)
                type = byte.MaxValue;

            if (param < 0)
                param = 0;
            else if (param > byte.MaxValue)
                param = byte.MaxValue;

            Object.Type = type;
            Object.Param = param;
            Object.Data = TxtData.Text;

            Refresh();
        }

        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtFrames_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtFrames.Text, out int frames);
            if (frames <= 0)
                TxtFrames.Text = 1.ToString();
            else if (frames > MaxFrames)
                TxtFrames.Text = MaxFrames.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Object.SetNull();
            AnimationStrip.Clear();
            TxtFrames.Text = 1.ToString();
            Refresh();
        }

        private void AnimationStrip_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = AnimationStrip.GetMouseToCellPos(e.Location);

            if (e.Button == MouseButtons.Left)
            {
                Animation.SetFrame(p.X, MapEditor.SelectedTile);
                AnimationStrip.Refresh();
            }
            else if (e.Button == MouseButtons.Right)
            {
                Tile tile = Animation.GetFrame(p.X);
                MapEditor.SelectedTile = tile;
            }
        }

        public void UpdateAnimation(ObjectAnim anim)
        {
            Animation.SetEqual(anim);
            AnimationFrameCount = anim.Size;

            while (Animation.Size < MaxFrames)
                Animation.AddFrame(new Tile(0, 0, AnimationStrip.Graphics.Palette.Size - 1));
        }

        private void BtnExpandData_Click(object sender, EventArgs e)
        {
            DataInputWindow win = new DataInputWindow();
            if (win.ShowDialog(this, TxtData.Text) == DialogResult.OK)
                TxtData.Text = win.Data;
        }
    }
}