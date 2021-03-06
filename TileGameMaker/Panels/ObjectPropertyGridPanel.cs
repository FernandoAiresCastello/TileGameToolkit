﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameMaker.MapEditorElements;
using TileGameLib.Util;
using TileGameMaker.Windows;

namespace TileGameMaker.Panels
{
    public partial class ObjectPropertyGridPanel : UserControl
    {
        public PropertyList Properties => GetProperties();

        public ObjectPropertyGridPanel()
        {
            InitializeComponent();

            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid.RowHeadersWidth = 20;

            Grid.Columns.Add("property", "Property");
            Grid.Columns.Add("value", "Value");
        }

        public void UpdateProperties(GameObject o)
        {
            Grid.Rows.Clear();

            if (o != null)
            {
                foreach (var prop in o.Properties.Entries)
                    Grid.Rows.Add(prop.Key, prop.Value);

                Refresh();
            }
        }

        public PropertyList GetProperties()
        {
            PropertyList properties = new PropertyList();

            foreach (DataGridViewRow row in Grid.Rows)
            {
                object objProperty = row.Cells["property"].Value;
                object objValue = row.Cells["value"].Value ?? "";

                if (objProperty != null && !string.IsNullOrWhiteSpace(objProperty.ToString()))
                    properties.Set(objProperty.ToString(), objValue.ToString());
            }

            return properties;
        }

        private void RemoveSelectedProperty()
        {
            if (Grid.SelectedCells.Count > 0)
            {
                foreach(DataGridViewCell cell in Grid.SelectedCells)
                {
                    DataGridViewRow row = cell.OwningRow;

                    if (Grid.Rows.Contains(row) && !row.IsNewRow)
                    {
                        Grid.Rows.Remove(row);
                        Refresh();
                    }
                }
            }
        }

        private void RemoveAllProperties()
        {
            Grid.Rows.Clear();
        }

        private void BtnDeleteSelectedProperty_Click(object sender, EventArgs e)
        {
            RemoveSelectedProperty();
        }

        private void BtnDeleteAllProperties_Click(object sender, EventArgs e)
        {
            RemoveAllProperties();
        }

        private void BtnOpenTextEditor_Click(object sender, EventArgs e)
        {
            if (Grid.SelectedCells.Count == 0)
                return;

            TextInputWindow win = new TextInputWindow("Edit property");
            string currentValue = Grid.SelectedCells[0].Value != null ? Grid.SelectedCells[0].Value.ToString() : "";

            if (win.ShowDialog(this, currentValue) == DialogResult.OK)
            {
                Grid.SelectedCells[0].Value = win.Text;
                Refresh();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Grid.Rows.Add();
        }

        private void BtnGenerateId_Click(object sender, EventArgs e)
        {
            bool hasId = false;

            foreach (DataGridViewRow row in Grid.Rows)
            {
                object prop = row.Cells[0].Value;
                if (prop != null && prop.ToString().ToLower() == "id")
                    hasId = true;
            }

            if (!hasId)
                Grid.Rows.Add("id", RandomID.Generate(8));
            else
                Alert.Warning("This object already has an ID");
        }
    }
}
