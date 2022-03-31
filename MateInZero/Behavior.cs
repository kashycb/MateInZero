using System;
using System.Linq;

namespace MateInZero
{
    public abstract class Behavior
    {
        public abstract Move pickMove(int x, int y, Piece actor);
    }
}

