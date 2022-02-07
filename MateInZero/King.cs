using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class King : Piece
    {
        public SortedList<int, Tuple<string, Piece>> suggestedMoves;

        public KingBehavior behavior;

        public override void suggestMove()
        {
            Tuple<int, Tuple<string, Piece>> move = pickMove();
            this.suggestedMoves.Add(move.Item1, move.Item2);
        }

        public void playMove()
        {
            //pick the best move and play it if it does not threaten the king.
            foreach (KeyValuePair<int, Tuple<string, Piece>> pair in suggestedMoves)
            {
                //check if the move is safe
                //if it is play it and break
                //if it is not check the next move
            }
        }
    }
}
