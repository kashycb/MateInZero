using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class Rook : Piece
    {
        //remove deafault constructor
        private Rook() { }
        public GameBoard gameBoard;
        public bool castleRights = true;
        public Rook(GameBoard board, char file, King k)
        {
            var lettermap = new Dictionary<char, int> {
            {'a', 0},{'h', 7},
            };
            gameBoard = board;
            king = k;
            this.white = king.white;
            this.type = "Rook";
            int result;
            lettermap.TryGetValue(Char.ToLower(file), out result);
            if (this.white)
            {
                this.currentPosition = Tuple.Create<int, int>(result, 0);
                this.name = "White-" + file.ToString() + "-Rook";
            }
            else
            {
                this.currentPosition = Tuple.Create<int, int>(result, 7);
                this.name = "Black-" + file.ToString() + "-Rook";
            }


            this.behavior = new RookBehavior(this.king);//Define the behavior
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

