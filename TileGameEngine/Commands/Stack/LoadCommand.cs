﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Stack
{
    public class LoadCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string variable = immediateParams[0];
            AssertVariable(variable);
            string value = Environment.GetVariable(variable);
            ParamStack.Push(value);
        }
    }
}