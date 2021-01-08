﻿namespace TileGameMaker.Windows
{
    partial class ProgramEditorWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAccept = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.TxtProgram = new System.Windows.Forms.TextBox();
            this.BtnRunEngine = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtProgram, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 515);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAccept,
            this.BtnCancel,
            this.BtnRunEngine});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(418, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnAccept
            // 
            this.BtnAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAccept.Image = global::TileGameMaker.Properties.Resources.tick;
            this.BtnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(23, 20);
            this.BtnAccept.Text = "toolStripButton1";
            this.BtnAccept.ToolTipText = "Confirm";
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.undo;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(23, 20);
            this.BtnCancel.Text = "toolStripButton2";
            this.BtnCancel.ToolTipText = "Cancel";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtProgram
            // 
            this.TxtProgram.AcceptsReturn = true;
            this.TxtProgram.AcceptsTab = true;
            this.TxtProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtProgram.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProgram.Location = new System.Drawing.Point(3, 29);
            this.TxtProgram.MaxLength = 65536;
            this.TxtProgram.Multiline = true;
            this.TxtProgram.Name = "TxtProgram";
            this.TxtProgram.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtProgram.Size = new System.Drawing.Size(412, 483);
            this.TxtProgram.TabIndex = 1;
            this.TxtProgram.WordWrap = false;
            // 
            // BtnRunEngine
            // 
            this.BtnRunEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnRunEngine.Image = global::TileGameMaker.Properties.Resources.control_play_blue;
            this.BtnRunEngine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRunEngine.Name = "BtnRunEngine";
            this.BtnRunEngine.Size = new System.Drawing.Size(23, 20);
            this.BtnRunEngine.Text = "toolStripButton1";
            this.BtnRunEngine.ToolTipText = "Save project and run engine";
            this.BtnRunEngine.Click += new System.EventHandler(this.BtnRunEngine_Click);
            // 
            // ProgramEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 515);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ProgramEditorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Editor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAccept;
        private System.Windows.Forms.ToolStripButton BtnCancel;
        private System.Windows.Forms.TextBox TxtProgram;
        private System.Windows.Forms.ToolStripButton BtnRunEngine;
    }
}