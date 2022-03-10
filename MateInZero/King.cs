using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class King : Piece
    {
        //remove deafault constructor
        private King(){ }
        public King(bool white, GameBoard gameBoard)
        {
            if (white)
            {
                this.currentPosition = Tuple.Create<int, int>(4, 0);
                this.name = "White-King";
            }
            else
            {
                this.currentPosition = Tuple.Create<int, int>(4, 7);
                this.name = "Black-King";
            }
            this.behavior = new KingBehavior();
            
        }

        //keep an array of subbordinate pieces
        //private Piece[] pieces = new Pieces[16]

        public Move[] suggestedMoves = new Move[16];

        //Check to see if a square is under threat
        private bool checkSafe(int x, int y)
        {
            return true;
        }

        public override void suggestMove()
        {
            //pick a move for the king
            Move pickedMove = pickMove(this);
            //Console.WriteLine("Picked move: " + pickedMove.endingSquare);
            for (int i = 0; i < suggestedMoves.Length; i++)
                if (suggestedMoves[i] == null)
                {
                    suggestedMoves[i] = pickedMove;
                    break;
                }
        }

        public Move playMove()
        {
            //get all moves from other pieces

            //get own move
            this.suggestMove();

            //pick the best move and play it if it does not threaten the king.
            Move bestMove = null;
            foreach (Move move in suggestedMoves)
            {
                if (move == null)
                    continue;
                if(bestMove == null || move.moveValue > bestMove.moveValue)
                {

                    //check if the move is safe here

                    bestMove = move;
                }
                Console.WriteLine("Suggested move:" + move.endingSquare + ',' + move.actor);
            }
            Console.WriteLine("Best move: " + bestMove.endingSquare + ',' + bestMove.actor);
            //clear suggested moves for next turn
            Array.Clear(this.suggestedMoves, 0, 16);
            return bestMove;
        }
    }
}
