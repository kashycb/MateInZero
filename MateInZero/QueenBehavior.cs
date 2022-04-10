using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class QueenBehavior : Behavior
    {
        private QueenBehavior() { }

        public QueenBehavior(King k)
        {
            king = k;
        }
        public King king;
        //Move values
        private int ESCAPE_THREAT = 25;
        private int CAPTURE_PIECE = 20;
        private int NON_ESSENTIAL_MOVE = 10;
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 5;

        //find the Queens's most preffered move
        public override Move pickMove(int x, int y, Piece actor)
        {
            Move[] moves = new Move[28];//Twenty-Eight possible moves
            int placementIndex = 0;
            //Check bishop-type moves
            for (int i = -1; i < 2; i += 2)//check up and down/left and right
            {
                for (int j = -1; j < 2; j += 2)
                {
                    int lat = x + i;
                    int vert = y + j;
                    while (lat <= 7 && lat >= 0 && vert <= 7 && vert >= 0)//check in a direction until board edge is reached
                    {
                        Piece piece = actor.king.gameBoard.boardGrid[lat, vert];
                        //check the move
                        //check for friendly piece
                        if (piece != null && piece.white == actor.white)
                        {
                            //rook cannot move to friendly square so stop checking this row
                            break;
                        }
                        else if (piece != null)//non friendly piece
                        {
                            //add the move as a capture
                            Move move = new Move { moveValue = CAPTURE_PIECE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(lat, vert), actor = actor };
                            moves[placementIndex] = move;
                            ++placementIndex;
                            break;
                        }
                        else//unnoccupied square
                        {
                            //add the move as a non-essential move
                            Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(lat, vert), actor = actor };
                            moves[placementIndex] = move;
                            ++placementIndex;
                        }

                        //increment
                        lat += i;
                        vert += j;
                    }
                }
            }
            //check rook-type moves
            for (int i = -1; i < 2; i += 2)//check up and down/left and right
            {
                for (int j = 0; j < 2; ++j)
                {
                    if (j == 0)//check lateral movement
                    {
                        int lat = x + i;
                        while (lat <= 7 && lat >= 0)//check in a direction until board edge is reached
                        {
                            Piece piece = actor.king.gameBoard.boardGrid[lat, y];
                            //check the move
                            //check for friendly piece
                            if (piece != null && piece.white == actor.white)
                            {
                                //rook cannot move to friendly square so stop checking this row
                                break;
                            }
                            else if (piece != null)//non friendly piece
                            {
                                //add the move as a capture
                                Move move = new Move { moveValue = CAPTURE_PIECE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(lat, y), actor = actor };
                                moves[placementIndex] = move;
                                ++placementIndex;
                                break;
                            }
                            else//unnoccupied square
                            {
                                //add the move as a non-essential move
                                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(lat, y), actor = actor };
                                moves[placementIndex] = move;
                                ++placementIndex;
                            }

                            //increment
                            lat += i;
                        }
                    }
                    else//check vertical movement
                    {
                        int vert = y + i;
                        while (vert <= 7 && vert >= 0)//check in a direction until board edge is reached
                        {
                            Piece piece = actor.king.gameBoard.boardGrid[x, vert];
                            //check the move
                            //check for friendly piece
                            if (piece != null && piece.white == actor.white)
                            {
                                //rook cannot move to friendly square so stop checking this column
                                break;
                            }
                            else if (piece != null)//non friendly piece
                            {
                                //add the move as a capture
                                Move move = new Move { moveValue = CAPTURE_PIECE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, vert), actor = actor };
                                moves[placementIndex] = move;
                                ++placementIndex;
                                break;
                            }
                            else//unnoccupied square
                            {
                                //add the move as a non-essential move
                                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, vert), actor = actor };
                                moves[placementIndex] = move;
                                ++placementIndex;
                            }

                            //increment
                            vert += i;
                        }
                    }
                }
            }

            //shuffle moves
            Random rnd = new Random();
            Move[] shuffledMoves = moves.OrderBy(M => rnd.Next()).ToArray();
            moves = shuffledMoves;

            Move bestMove = null;
            foreach (Move move in moves)
            {
                if (move != null)
                {
                    //evaluate the move and assign an appropriate value
                    //Console.WriteLine(move.endingSquare);
                    if (bestMove == null || move.moveValue > bestMove.moveValue)
                    {
                        bestMove = move;
                    }
                }
            }
            return bestMove;
        }
    }
}

