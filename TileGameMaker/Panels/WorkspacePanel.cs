﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using System.IO;
using TileGameLib.Util;
using TileGameLib.File;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace TileGameMaker.Panels
{
    public partial class WorkspacePanel : UserControl
    {
        public MapEditor MapEditor { get; set; }
        public bool CloseOnLoadFile { get; set; } = true;

        public WorkspacePanel() : this(null)
        {
        }

        public WorkspacePanel(MapEditor editor)
        {
            InitializeComponent();
            MapEditor = editor;
        }

        private void BtnOpenWorkspace_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            dialog.InitialDirectory = MapEditor.WorkspacePath;

            if (dialog.ShowDialog(Parent.Handle) == CommonFileDialogResult.Ok)
            {
                MapEditor.WorkspacePath = dialog.FileName;
                UpdateWorkspace();
            }
        }

        public void UpdateWorkspace()
        {
            TxtPath.Text = MapEditor.WorkspacePath ?? "";
            if (MapEditor.WorkspacePath == null)
                return;

            WorkspaceGrid.Rows.Clear();

            var filenames = Directory.EnumerateFiles(MapEditor.WorkspacePath);

            foreach (string name in filenames)
            {
                FileInfo file = new FileInfo(name);

                if (file.Extension == "." + FileExtensions.Map)
                {
                    double kb = file.Length / 1024d;
                    WorkspaceGrid.Rows.Add(file.Name, kb.ToString("0.##"), file.LastWriteTime);
                }
            }

            Refresh();
        }

        private void WorkspaceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (WorkspaceGrid.SelectedRows.Count > 0)
            {
                string file = WorkspaceGrid.SelectedRows[0].Cells[0].Value.ToString();
                string path = Path.Combine(MapEditor.WorkspacePath, file);
                MapEditor.MapEditorControl.LoadMap(path);

                if (CloseOnLoadFile && Parent is Form)
                    (Parent as Form).Close();
            }
        }
    }
}
