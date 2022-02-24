using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class King : Piece
    {
        //keep an array of subbordinate pieces

        public Move[] suggestedMoves;

        public KingBehavior behavior;

        public override void suggestMove()
        {
            Move pickedMove = pickMove();
            this.suggestedMoves.Append(pickedMove);
        }

        public void playMove()
        {
            //get all moves from other pieces

            //get own move

            //pick the best move and play it if it does not threaten the king.
            foreach (Move move in suggestedMoves)
            {
                //check if the move is safe and higher value than current choice
                //save index of higher value safe move
                //repeat for all moves
            }
            //play the best move
        }
    }
}
