using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public abstract class Piece
    {
        //controls how the piece moves and thinks
        private Behavior behavior;
        public Tuple<int, int> currentPosition;

        //wrap the find moves function from pieces behavior
        public Tuple<int, Tuple<string, Piece>> pickMove() 
        {
            return this.behavior.pickMove(currentPosition.Item1, currentPosition.Item2);
        }
        //should call findMoves() and pass the best move for this piece
        //to the king
        public abstract void suggestMove();

    }
}
