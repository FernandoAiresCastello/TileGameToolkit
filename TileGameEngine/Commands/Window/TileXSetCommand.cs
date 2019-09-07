﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Window
{
    public class TileXSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int x = PopInt();
            Environment.SetWindowCursorX(x);
        }
    }
}