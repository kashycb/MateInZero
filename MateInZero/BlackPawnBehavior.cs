using System;
using System.Linq;

namespace MateInZero
{
    public class BlackPawnBehvaior : Behavior
    {
        private BlackPawnBehvaior() { }

        public BlackPawnBehvaior(King k)
        {
            king = k;
        }
        public King king;
        //Move values
        private int PROMOTE = 45;
        private int ESCAPE_THREAT = 21;
        private int CAPTURE_PIECE = 20;
        private int NON_ESSENTIAL_MOVE = 10;
        private int ENPASSANT = 1000;
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 1;

        //find the piece's most preffered move
        public override Move pickMove(int x, int y, Piece actor)
        {
            int turnPriorityAdjust = 0;
            if (this.king.gameBoard.numMoves < 10)
            {
                turnPriorityAdjust = 1;
            }
            Move[] moves = new Move[6];//six possible moves including enn passant
            int placementIndex = 0;
            for (int i = -1; i < 2; ++i)
            {
                if (y > 1 && i != 0 && x + i <= 7 && x + i >= 0 && this.king.gameBoard.boardGrid[x + i, y - 1] != null && this.king.gameBoard.boardGrid[x + i, y - 1].white != actor.white)
                {
                    //a pawn can capture a piece
                    Move move = new Move { moveValue = CAPTURE_PIECE * (PRIORITY_MULTIPLYER + turnPriorityAdjust), startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y - 1), actor = actor };
                    moves[placementIndex] = move;
                    ++placementIndex;
                }
            }
            for (int i = -1; i < 2; ++i)//check en passant
            {
                if (x + i >= 0 && x + i <= 7)
                {
                    Piece piece = this.king.gameBoard.boardGrid[x + i, y];
                    if (y < 7 && i != 0 && x + i <= 7 && x + i >= 0 && piece != null && piece.type == "Pawn" && piece.white)
                    {
                        if (((WhitePawn)piece).enPassantTarget)
                        {
                            Move move = new Move { moveValue = ENPASSANT * (PRIORITY_MULTIPLYER + turnPriorityAdjust), startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y), actor = actor };
                            moves[placementIndex] = move;
                            ++placementIndex;
                        }
                    }
                }
            }
            if (y == 6 && king.gameBoard.boardGrid[x, y - 2] == null && king.gameBoard.boardGrid[x, y - 1] == null)
            {
                //2 square move
                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * (PRIORITY_MULTIPLYER + turnPriorityAdjust), startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y - 2), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
            }
            if (y - 1 > 0 && king.gameBoard.boardGrid[x, y - 1] == null)
            {
                //1 square move
                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE * (PRIORITY_MULTIPLYER + turnPriorityAdjust), startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y - 1), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
            }
            if (y - 1 == 0 && king.gameBoard.boardGrid[x, y - 1] == null)
            {
                //promotion
                Move move = new Move { moveValue = PROMOTE * (PRIORITY_MULTIPLYER + turnPriorityAdjust), startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y - 1), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
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

