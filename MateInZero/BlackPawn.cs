using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class BlackPawn : Piece
    {
        //remove deafault constructor
        private BlackPawn() { }
        public GameBoard gameBoard;
        public BlackPawn(GameBoard board, char file, King k)
        {
            this.white = false;
            var lettermap = new Dictionary<char, int> {
            {'a', 0},{'b', 1},{'c', 2},{'d', 3},{'e', 4},{'f', 5},{'g', 6},{'h', 7},
            };

            gameBoard = board;
            king = k;
            this.type = "Pawn";
            int result;
            lettermap.TryGetValue(Char.ToLower(file), out result);
            this.currentPosition = Tuple.Create<int, int>(result, 6);
            this.name = "Black-" + file.ToString() + "-Pawn";
            this.behavior = new BlackPawnBehvaior(this.king);//Define the behavior
        }

        public override void suggestMove()
        {
            //pick a move for the pawn
            Move pickedMove = pickMove(this);
            //add suggested move to the king's list
            int i;
            for(i = 0; king.suggestedMoves[i] != null; ++i)
                continue;
            king.suggestedMoves[i] = pickedMove;
        }
    }
}
