using System;
using System.Linq;

namespace MateInZero
{
    //king
    public class KingBehavior : Behavior
    {
        private KingBehavior() { }

        public KingBehavior(King k)
        {
            king = k;
        }
        public King king;
        //Move values
        private int ESCAPE_THREAT = 100;
        private int CAPTURE_PIECE = 10;
        private int NON_ESSENTIAL_MOVE = 1;
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 7;

        //find the king's most preffered move
        public override Move pickMove(int x, int y, Piece actor)
        {
            Move[] moves = new Move[8];//eight possible moves
            int placementIndex = 0;
            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;
                    //validate
                    if (x + i < 0 || x + i > 7 || y + j < 0 || y + j > 7)
                    {
                        //invalid sqaure on the board
                        moves[placementIndex] = null;
                    }
                    else if (king.gameBoard.boardGrid[x + i, y + j] != null)
                    {
                        if (king.gameBoard.boardGrid[x + i, y + j].white != king.white)
                        {
                            //valid capture
                            Move move = new Move { moveValue = CAPTURE_PIECE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + j), actor = actor };
                            moves[placementIndex] = move;
                        }
                    }
                    else
                    {
                        //valid move
                        Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + j), actor = actor };
                        moves[placementIndex] = move;
                    }
                    placementIndex++;
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
                        //check if a square is under attack
                        //king will not move to/remain on a square if it is under attack
                        if (king.checkSafe(move.endingSquare.Item1, move.endingSquare.Item2))
                        {
                            bestMove = move;
                        }
                    }
                }
            }
            return bestMove;
        }
    }
}

