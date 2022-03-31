using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class Bishop : Piece
    {
        //remove deafault constructor
        private Bishop() { }
        public GameBoard gameBoard;
        public Bishop(GameBoard board, char file, King k)
        {
            var lettermap = new Dictionary<char, int> {
            {'c', 2},{'f', 5},
            };
            gameBoard = board;
            king = k;
            this.white = king.white;
            this.type = "Bishop";
            int result;
            lettermap.TryGetValue(Char.ToLower(file), out result);
            if (this.white)
            {
                this.currentPosition = Tuple.Create<int, int>(result, 0);
                this.name = "White-" + file.ToString() + "-Bishop";
            }
            else
            {
                this.currentPosition = Tuple.Create<int, int>(result, 7);
                this.name = "Black-" + file.ToString() + "-Bishop";
            }


            this.behavior = new BishopBehavior(this.king);//Define the behavior
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

