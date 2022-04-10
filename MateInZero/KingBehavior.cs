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
            Move[] moves = new Move[10];//ten possible moves includes long and short castle
            int placementIndex = 0;

            //check short and long castle
            if (actor.white && king.castleRights)
            {
                Piece piece = king.gameBoard.boardGrid[7, 0];
                if (piece != null && piece.type == "Rook")
                {
                    Rook hRook = (Rook)piece;
                    if(hRook.castleRights && king.gameBoard.boardGrid[6, 0] == null && king.gameBoard.boardGrid[5, 0] == null)
                    {
                        //castle short
                        Move move = new Move { moveValue = ESCAPE_THREAT * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(6, 0), actor = actor };
                        moves[placementIndex] = move;
                        ++placementIndex;        
                    }
                }
                piece = king.gameBoard.boardGrid[0, 0];
                if (piece != null && piece.type == "Rook")
                {
                    Rook hRook = (Rook)piece;
                    if (hRook.castleRights && king.gameBoard.boardGrid[1, 0] == null && king.gameBoard.boardGrid[2, 0] == null && king.gameBoard.boardGrid[3, 0] == null)
                    {
                        //castle short
                        Move move = new Move { moveValue = ESCAPE_THREAT * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(2, 0), actor = actor };
                        moves[placementIndex] = move;
                        ++placementIndex;
                    }
                }
            }
            else if(king.castleRights)
            {
                Piece piece = king.gameBoard.boardGrid[7, 7];
                if (piece != null && piece.type == "Rook")
                {
                    Rook hRook = (Rook)piece;
                    if (hRook.castleRights && king.gameBoard.boardGrid[6, 7] == null && king.gameBoard.boardGrid[5, 7] == null)
                    {
                        //castle short
                        Move move = new Move { moveValue = ESCAPE_THREAT * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(6, 7), actor = actor };
                        moves[placementIndex] = move;
                    }
                }
                piece = king.gameBoard.boardGrid[0, 7];
                if (piece != null && piece.type == "Rook")
                {
                    Rook hRook = (Rook)piece;
                    if (hRook.castleRights && king.gameBoard.boardGrid[1, 7] == null && king.gameBoard.boardGrid[2, 7] == null && king.gameBoard.boardGrid[3, 7] == null)
                    {
                        //castle short
                        Move move = new Move { moveValue = ESCAPE_THREAT * PRIORITY_MULTIPLYER, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(2, 7), actor = actor };
                        moves[placementIndex] = move;
                        ++placementIndex;
                    }
                }
            }
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

