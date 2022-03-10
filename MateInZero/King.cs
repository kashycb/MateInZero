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
        
        public GameBoard gameBoard;
        public King(bool white, GameBoard board)
        {
            gameBoard = board;
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
            this.behavior = new KingBehavior(this);
            
        }

        //keep an array of subbordinate pieces
        //private Piece[] pieces = new Pieces[16]

        public Move[] suggestedMoves = new Move[16];

        //Check to see if a square is under threat
        public bool checkSafe(int x, int y)
        {
            //check that there is no king threatening a square
            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;
                    //validate
                    if (x + i < 0 || x + i > 7 || y + j < 0 || y + j > 7)
                    {
                        //skip invalid square
                        continue;
                    }
                    if (gameBoard.boardGrid[x + i, y + j] != null)
                    {
                        Piece piece = gameBoard.boardGrid[x + i, y + j];
                        Console.WriteLine(piece);
                        if(piece.name == "Black-King" || piece.name == "White-King")
                        {
                            //ignore yourself
                            if (piece.name == this.name)
                                continue;
                            //only accept a move that is safe
                            return false;
                        }
                    }
                }
            }
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

                    //check if the move is safe
                    if(checkSafe(move.endingSquare.Item1, move.endingSquare.Item2))
                    {
                        //only accept the move if it is safe
                        bestMove = move;
                    }
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
