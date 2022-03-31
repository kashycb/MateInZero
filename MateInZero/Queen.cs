using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class Queen : Piece
    {
        //remove deafault constructor
        private Queen() { }
        public GameBoard gameBoard;
        public Queen(GameBoard board, char file, King k)
        {
            gameBoard = board;
            king = k;
            this.white = king.white;
            this.type = "Rook";
            if (this.white)
            {
                this.currentPosition = Tuple.Create<int, int>(3, 0);
                this.name = "White-Queen";
            }
            else
            {
                this.currentPosition = Tuple.Create<int, int>(3, 7);
                this.name = "Black-Queen";
            }


            this.behavior = new QueenBehavior(this.king);//Define the behavior
        }

        public override void suggestMove()
        {
            //pick a move for the rook
            Move pickedMove = pickMove(this);
            //add suggested move to the king's list
            int i;
            for (i = 0; king.suggestedMoves[i] != null; ++i)
                continue;
            king.suggestedMoves[i] = pickedMove;
        }
    }
}

