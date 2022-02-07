using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public abstract class Behavior
    {
        public abstract Tuple<int, Tuple<string, Piece>> pickMove(int x, int y);
    }

    //king
    public class KingBehavior : Behavior
    {
        //The king does not need a vision pattern since it can see the whole board

        //Move values (more negative is more prioritized)
        private int ESCAPE_THREAT = -100;
        private int CAPTURE_PIECE = -10;
        private int NON_ESSENTIAL_MOVE = -1;
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 7;

        //find the king's most preffered move
        public override Tuple<int, Tuple<string, Piece>> pickMove(int x, int y)
        {
            Tuple<int, Tuple<string, Piece>>[] moves = new Tuple<int, Tuple<string, Piece>>[8];
            //do some work to find kings moves
            //do some more work to pick best option and return it
            return Tuple.Create<int, Tuple<string, Piece>>(0, Tuple.Create<string, Piece>(null, null));
        }

        //check if a square is under attack
        //king will not move to/remain on a square if it is under attack
        private bool checkThreats(int x, int y)
        {
            return false;
        }
    }
}

