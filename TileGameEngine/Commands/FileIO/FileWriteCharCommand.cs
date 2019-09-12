﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.FileIO
{
    public class FileWriteCharCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string value = PopStr();
            if (value.Length >= 1)
                Environment.MemoryFile.WriteChar(value[0]);
        }
    }
}