using System;
using System.Linq;

namespace MateInZero
{
    public class KnightBehavior : Behavior
    {
        private KnightBehavior() { }

        public KnightBehavior(King k)
        {
            king = k;
        }
        public King king;
        //Move values
        private int ESCAPE_THREAT = 25;
        private int CAPTURE_PIECE = 20;
        private int NON_ESSENTIAL_MOVE = 10;
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 2;

        //find the king's most preffered move
        public override Move pickMove(int x, int y, Piece actor)
        {
            Move[] moves = new Move[8];//eight possible moves
            int placementIndex = 0;
            for (int i = -2; i < 3; i += 1)
            {
                if (i == 0)//skip middle square
                    continue;
                int yAdjust = 0;
                for (int j = -1; j < 2; j += 2)
                {
                    if (i == -2 || i == 2)
                    {
                        yAdjust = 1 * j;
                    }
                    else
                    {
                        yAdjust = 2 * j;
                    }
                    if (x + i < 0 || x + i > 7 || y + yAdjust < 0 || y + yAdjust > 7)//invalid move
                        continue;
                    Piece piece = actor.king.gameBoard.boardGrid[x + i, y + yAdjust];
                    if (piece == null)
                    {
                        //valid move to empty square
                        Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + yAdjust), actor = actor };
                        moves[placementIndex] = move;
                        ++placementIndex;
                    }
                    else if (piece.white != actor.white)
                    {
                        //valid move to capture
                        Move move = new Move { moveValue = CAPTURE_PIECE * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + yAdjust), actor = actor };
                        moves[placementIndex] = move;
                        ++placementIndex;
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

