using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class Knight : Piece
    {
        //remove deafault constructor
        private Knight() { }
        public GameBoard gameBoard;
        public Knight(GameBoard board, char file, King k)
        {
            var lettermap = new Dictionary<char, int> {
            {'a', 0},{'b', 1},{'c', 2},{'d', 3},{'e', 4},{'f', 5},{'g', 6},{'h', 7},
            };
            gameBoard = board;
            king = k;
            this.white = king.white;
            this.type = "Pawn";
            int result;
            lettermap.TryGetValue(Char.ToLower(file), out result);
            if (this.white)
            {
                this.currentPosition = Tuple.Create<int, int>(result, 0);
                this.name = "White-" + file.ToString() + "-Knight";
            }
            else
            {
                this.currentPosition = Tuple.Create<int, int>(result, 7);
                this.name = "Black-" + file.ToString() + "-Knight";
            }
            
            
            this.behavior = new KnightBehacior(this.king);//Define the behavior
        }

        public override void suggestMove()
        {
            //pick a move for the pawn
            Move pickedMove = pickMove(this);
            //add suggested move to the king's list
            int i;
            for (i = 0; king.suggestedMoves[i] != null; ++i)
                continue;
            king.suggestedMoves[i] = pickedMove;
        }
    }
}
