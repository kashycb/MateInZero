﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public abstract class Behavior
    {
        public abstract Tuple<int, string>[] findMoves();
    }
}