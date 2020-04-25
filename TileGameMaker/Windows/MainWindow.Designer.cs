﻿namespace TileGameMaker.Windows
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnViewWorkspace = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnDataExtractor = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnOpenMusicComposer = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MapPropertiesPanel = new System.Windows.Forms.Panel();
            this.WorkspacePanel = new System.Windows.Forms.Panel();
            this.ColorPickerPanel = new System.Windows.Forms.Panel();
            this.TilePickerPanel = new System.Windows.Forms.Panel();
            this.MapAndCommandLineSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CentralSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MapEditorPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TemplateLibraryPanel = new System.Windows.Forms.Panel();
            this.CommandLinePanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.WindowLayout.SuspendLayout();
            this.MainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapAndCommandLineSplitContainer)).BeginInit();
            this.MapAndCommandLineSplitContainer.Panel1.SuspendLayout();
            this.MapAndCommandLineSplitContainer.Panel2.SuspendLayout();
            this.MapAndCommandLineSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CentralSplitContainer)).BeginInit();
            this.CentralSplitContainer.Panel1.SuspendLayout();
            this.CentralSplitContainer.Panel2.SuspendLayout();
            this.CentralSplitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.fileToolStripMenuItem.Text = "Application";
            // 
            // MiExit
            // 
            this.MiExit.Image = global::TileGameMaker.Properties.Resources.cross;
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(92, 22);
            this.MiExit.Text = "Exit";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnViewWorkspace,
            this.BtnDataExtractor,
            this.BtnOpenMusicComposer});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // BtnViewWorkspace
            // 
            this.BtnViewWorkspace.Image = global::TileGameMaker.Properties.Resources.folder_vertical_open;
            this.BtnViewWorkspace.Name = "BtnViewWorkspace";
            this.BtnViewWorkspace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.BtnViewWorkspace.Size = new System.Drawing.Size(203, 22);
            this.BtnViewWorkspace.Text = "View workspace";
            this.BtnViewWorkspace.Click += new System.EventHandler(this.BtnViewWorkspace_Click);
            // 
            // BtnDataExtractor
            // 
            this.BtnDataExtractor.Image = global::TileGameMaker.Properties.Resources.database_lightning;
            this.BtnDataExtractor.Name = "BtnDataExtractor";
            this.BtnDataExtractor.Size = new System.Drawing.Size(203, 22);
            this.BtnDataExtractor.Text = "Data extractor";
            this.BtnDataExtractor.Click += new System.EventHandler(this.BtnDataExtractor_Click);
            // 
            // BtnOpenMusicComposer
            // 
            this.BtnOpenMusicComposer.Image = global::TileGameMaker.Properties.Resources.music;
            this.BtnOpenMusicComposer.Name = "BtnOpenMusicComposer";
            this.BtnOpenMusicComposer.Size = new System.Drawing.Size(203, 22);
            this.BtnOpenMusicComposer.Text = "Online music composer";
            this.BtnOpenMusicComposer.Click += new System.EventHandler(this.BtnOpenMusicComposer_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MiAbout
            // 
            this.MiAbout.Image = global::TileGameMaker.Properties.Resources.information;
            this.MiAbout.Name = "MiAbout";
            this.MiAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MiAbout.Size = new System.Drawing.Size(135, 22);
            this.MiAbout.Text = "About...";
            this.MiAbout.Click += new System.EventHandler(this.MiAbout_Click);
            // 
            // WindowLayout
            // 
            this.WindowLayout.ColumnCount = 1;
            this.WindowLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowLayout.Controls.Add(this.MainLayout, 0, 0);
            this.WindowLayout.Controls.Add(this.statusStrip1, 0, 1);
            this.WindowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowLayout.Location = new System.Drawing.Point(0, 24);
            this.WindowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.WindowLayout.Name = "WindowLayout";
            this.WindowLayout.RowCount = 2;
            this.WindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.WindowLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.WindowLayout.Size = new System.Drawing.Size(784, 426);
            this.WindowLayout.TabIndex = 2;
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 3;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainLayout.Controls.Add(this.MapPropertiesPanel, 2, 1);
            this.MainLayout.Controls.Add(this.WorkspacePanel, 2, 0);
            this.MainLayout.Controls.Add(this.ColorPickerPanel, 0, 1);
            this.MainLayout.Controls.Add(this.TilePickerPanel, 0, 0);
            this.MainLayout.Controls.Add(this.MapAndCommandLineSplitContainer, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 344F));
            this.MainLayout.Size = new System.Drawing.Size(784, 404);
            this.MainLayout.TabIndex = 1;
            // 
            // MapPropertiesPanel
            // 
            this.MapPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPropertiesPanel.Location = new System.Drawing.Point(655, 63);
            this.MapPropertiesPanel.Name = "MapPropertiesPanel";
            this.MapPropertiesPanel.Size = new System.Drawing.Size(126, 338);
            this.MapPropertiesPanel.TabIndex = 4;
            // 
            // WorkspacePanel
            // 
            this.WorkspacePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkspacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorkspacePanel.Location = new System.Drawing.Point(655, 3);
            this.WorkspacePanel.Name = "WorkspacePanel";
            this.WorkspacePanel.Size = new System.Drawing.Size(126, 54);
            this.WorkspacePanel.TabIndex = 3;
            // 
            // ColorPickerPanel
            // 
            this.ColorPickerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorPickerPanel.Location = new System.Drawing.Point(3, 63);
            this.ColorPickerPanel.Name = "ColorPickerPanel";
            this.ColorPickerPanel.Size = new System.Drawing.Size(124, 338);
            this.ColorPickerPanel.TabIndex = 2;
            // 
            // TilePickerPanel
            // 
            this.TilePickerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TilePickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TilePickerPanel.Location = new System.Drawing.Point(3, 3);
            this.TilePickerPanel.Name = "TilePickerPanel";
            this.TilePickerPanel.Size = new System.Drawing.Size(124, 54);
            this.TilePickerPanel.TabIndex = 1;
            // 
            // MapAndCommandLineSplitContainer
            // 
            this.MapAndCommandLineSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapAndCommandLineSplitContainer.Location = new System.Drawing.Point(133, 3);
            this.MapAndCommandLineSplitContainer.Name = "MapAndCommandLineSplitContainer";
            this.MapAndCommandLineSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapAndCommandLineSplitContainer.Panel1
            // 
            this.MapAndCommandLineSplitContainer.Panel1.Controls.Add(this.CentralSplitContainer);
            // 
            // MapAndCommandLineSplitContainer.Panel2
            // 
            this.MapAndCommandLineSplitContainer.Panel2.Controls.Add(this.CommandLinePanel);
            this.MapAndCommandLineSplitContainer.Panel2Collapsed = true;
            this.MainLayout.SetRowSpan(this.MapAndCommandLineSplitContainer, 2);
            this.MapAndCommandLineSplitContainer.Size = new System.Drawing.Size(516, 398);
            this.MapAndCommandLineSplitContainer.SplitterDistance = 323;
            this.MapAndCommandLineSplitContainer.TabIndex = 5;
            // 
            // CentralSplitContainer
            // 
            this.CentralSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CentralSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.CentralSplitContainer.Name = "CentralSplitContainer";
            // 
            // CentralSplitContainer.Panel1
            // 
            this.CentralSplitContainer.Panel1.Controls.Add(this.MapEditorPanel);
            // 
            // CentralSplitContainer.Panel2
            // 
            this.CentralSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.CentralSplitContainer.Panel2Collapsed = true;
            this.CentralSplitContainer.Size = new System.Drawing.Size(516, 398);
            this.CentralSplitContainer.SplitterDistance = 350;
            this.CentralSplitContainer.TabIndex = 2;
            // 
            // MapEditorPanel
            // 
            this.MapEditorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapEditorPanel.Location = new System.Drawing.Point(0, 0);
            this.MapEditorPanel.Name = "MapEditorPanel";
            this.MapEditorPanel.Size = new System.Drawing.Size(516, 398);
            this.MapEditorPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TemplateLibraryPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.904632F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.09537F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(96, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 4);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template Library";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TemplateLibraryPanel
            // 
            this.TemplateLibraryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TemplateLibraryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateLibraryPanel.Location = new System.Drawing.Point(3, 7);
            this.TemplateLibraryPanel.Name = "TemplateLibraryPanel";
            this.TemplateLibraryPanel.Size = new System.Drawing.Size(90, 90);
            this.TemplateLibraryPanel.TabIndex = 1;
            // 
            // CommandLinePanel
            // 
            this.CommandLinePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandLinePanel.Location = new System.Drawing.Point(0, 0);
            this.CommandLinePanel.Name = "CommandLinePanel";
            this.CommandLinePanel.Size = new System.Drawing.Size(150, 46);
            this.CommandLinePanel.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.WindowLayout);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Game Maker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.WindowLayout.ResumeLayout(false);
            this.WindowLayout.PerformLayout();
            this.MainLayout.ResumeLayout(false);
            this.MapAndCommandLineSplitContainer.Panel1.ResumeLayout(false);
            this.MapAndCommandLineSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapAndCommandLineSplitContainer)).EndInit();
            this.MapAndCommandLineSplitContainer.ResumeLayout(false);
            this.CentralSplitContainer.Panel1.ResumeLayout(false);
            this.CentralSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CentralSplitContainer)).EndInit();
            this.CentralSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MiAbout;
        private System.Windows.Forms.TableLayoutPanel WindowLayout;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Panel MapPropertiesPanel;
        private System.Windows.Forms.Panel WorkspacePanel;
        private System.Windows.Forms.Panel ColorPickerPanel;
        private System.Windows.Forms.Panel TilePickerPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer MapAndCommandLineSplitContainer;
        private System.Windows.Forms.Panel MapEditorPanel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Panel CommandLinePanel;
        private System.Windows.Forms.ToolStripMenuItem BtnDataExtractor;
        private System.Windows.Forms.SplitContainer CentralSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem BtnViewWorkspace;
        private System.Windows.Forms.ToolStripMenuItem BtnOpenMusicComposer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel TemplateLibraryPanel;
    }
}