﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;

namespace TileGameEngine
{
    public class Environment
    {
        public Project Project { get; private set; }
        public GameWindow Window { get; private set; }

        public Environment(Project project, GameWindow window)
        {
            Project = project;
            Window = window;
        }
    }
}
