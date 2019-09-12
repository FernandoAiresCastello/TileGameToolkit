﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectPropertyGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string property = PopStr();

            string value = Environment.GetObjectProperty(property);

            Push(value);
        }
    }
}