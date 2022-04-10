using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public abstract class Piece
    {
        public bool white;
        public string name;
        public string type;
        public King king;
        //controls how the piece moves and thinks
        public Behavior behavior;
        //Where the piece is on the board (x,y) cartesian coords
        public Tuple<int, int> currentPosition;

        //wrap the find moves function from pieces behavior
        public Move pickMove(Piece actor) 
        {
            return actor.behavior.pickMove(currentPosition.Item1, currentPosition.Item2, actor);
        }
        //should call findMoves() and pass the best move for this piece
        //to the king
        public abstract void suggestMove();

    }
}
