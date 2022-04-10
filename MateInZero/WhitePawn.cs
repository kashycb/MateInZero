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
    public class WhitePawn : Piece
    {
        //remove deafault constructor
        private WhitePawn() { }
        public GameBoard gameBoard;
        public bool enPassantTarget = false;
        public WhitePawn(GameBoard board, char file, King k)
        {
            this.white = true;
            var lettermap = new Dictionary<char, int> {
            {'a', 0},{'b', 1},{'c', 2},{'d', 3},{'e', 4},{'f', 5},{'g', 6},{'h', 7},
            };
            this.type = "Pawn";
            gameBoard = board;
            king = k;
            int result;
            lettermap.TryGetValue(Char.ToLower(file), out result);
            this.currentPosition = Tuple.Create<int, int>(result, 1);
            this.name = "White-" + file.ToString() + "-Pawn";
            this.behavior = new WhitePawnBehavior(this.king);//Define the behavior
        }

        public override void suggestMove()
        {
            this.enPassantTarget = false;
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
