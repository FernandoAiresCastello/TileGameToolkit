﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameRunner.Exceptions
{
    public class InterpreterException : Exception
    {
        public InterpreterException(string msg) : base(msg)
        {
        }
    }
}
