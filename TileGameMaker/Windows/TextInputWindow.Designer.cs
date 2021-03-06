﻿namespace TileGameMaker.Windows
{
    partial class TextInputWindow
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LbOrientation = new System.Windows.Forms.ToolStripLabel();
            this.CmbOrientation = new System.Windows.Forms.ToolStripComboBox();
            this.TxtText = new System.Windows.Forms.TextBox();
            this.BtnAccept = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.ToolStripButton();
            this.BtnToggleWordWrap = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TxtText, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAccept,
            this.BtnCancel,
            this.toolStripSeparator1,
            this.LbOrientation,
            this.CmbOrientation,
            this.BtnToggleWordWrap});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(539, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // LbOrientation
            // 
            this.LbOrientation.Name = "LbOrientation";
            this.LbOrientation.Size = new System.Drawing.Size(67, 20);
            this.LbOrientation.Text = "Orientation";
            // 
            // CmbOrientation
            // 
            this.CmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOrientation.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.CmbOrientation.Name = "CmbOrientation";
            this.CmbOrientation.Size = new System.Drawing.Size(121, 23);
            // 
            // TxtText
            // 
            this.TxtText.AcceptsReturn = true;
            this.TxtText.AcceptsTab = true;
            this.TxtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtText.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtText.Location = new System.Drawing.Point(3, 29);
            this.TxtText.MaxLength = 65536;
            this.TxtText.Multiline = true;
            this.TxtText.Name = "TxtText";
            this.TxtText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtText.Size = new System.Drawing.Size(533, 309);
            this.TxtText.TabIndex = 1;
            this.TxtText.WordWrap = false;
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
            this.BtnCancel.Image = global::TileGameMaker.Properties.Resources.cross;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(23, 20);
            this.BtnCancel.Text = "toolStripButton2";
            this.BtnCancel.ToolTipText = "Cancel";
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnToggleWordWrap
            // 
            this.BtnToggleWordWrap.CheckOnClick = true;
            this.BtnToggleWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnToggleWordWrap.Image = global::TileGameMaker.Properties.Resources.word_wrap;
            this.BtnToggleWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnToggleWordWrap.Name = "BtnToggleWordWrap";
            this.BtnToggleWordWrap.Size = new System.Drawing.Size(23, 20);
            this.BtnToggleWordWrap.Text = "toolStripButton1";
            this.BtnToggleWordWrap.ToolTipText = "Toggle word wrap";
            this.BtnToggleWordWrap.Click += new System.EventHandler(this.BtnToggleWordWrap_Click);
            // 
            // TextInputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TextInputWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.TextBox TxtText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox CmbOrientation;
        private System.Windows.Forms.ToolStripLabel LbOrientation;
        private System.Windows.Forms.ToolStripButton BtnToggleWordWrap;
    }
}