﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Misc
{
    public class NopCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            // No operation
        }
    }
}