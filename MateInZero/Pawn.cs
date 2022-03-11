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

    namespace MateInZero
    {
        public class Pawn : Piece
        {
            //remove deafault constructor
            private Pawn() { }

            public GameBoard gameBoard;
            public Pawn(GameBoard board, bool white, char file, King king)
            {
                var lettermap = new Dictionary<char, int> {
                {'a', 0},{'b', 1},{'c', 2},{'d', 3},{'e', 4},{'f', 5},{'g', 6},{'h', 7},
                };

                gameBoard = board;
                if (white)
                {
                    this.currentPosition = Tuple.Create<int, int>(lettermap[file], 2);
                    this.name = "White-" + file.ToString() + "-Pawn";
                }
                else
                {
                    this.currentPosition = Tuple.Create<int, int>(lettermap[file], 7);
                    this.name = "Black-" + file.ToString() + "-Pawn";
                }
                this.behavior = new PawnBehavior(this);//Define the behavior

            }

            public override void suggestMove()
            {
                //pick a move for the pawn
                Move pickedMove = pickMove(this);
                //add suggested move to the king's list
            }
        }
    }
}
