﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameEngine.Windows;
using TileGameEngine.Exceptions;
using System.Windows.Forms;
using TileGameEngine.Util;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        public Variables Variables { get; private set; } = new Variables();

        public Environment()
        {
            DeleteLogFile();
        }

        public void ExitApplication()
        {
            if (HasWindow)
                CloseWindow();

            Application.Exit();
        }

        public void Reset()
        {
            DeleteLogFile();
            Variables.Clear();

            if (HasWindow)
                CloseWindow();

            Map = null;
            MapRenderer = null;
        }

        public void SetVariable(string variable, object value)
        {
            Variables.Set(variable.Substring(1), value);
        }

        public string GetVariable(string variable)
        {
            string name = variable.Substring(1);
            if (!Variables.Contains(name))
                throw new EnvironmentException("Variable not found: " + name);

            return Variables.GetStr(name);
        }
    }
}