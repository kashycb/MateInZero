using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public abstract class Behavior
    {
        public abstract Move pickMove(int x, int y, Piece actor);
    }

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
            for(int i = -1; i < 2; ++i)
            {
                for(int j = -1; j < 2; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;
                    //validate
                    if(x + i < 0 || x + i > 7 || y + j < 0 || y + j > 7)
                    {
                        //invalid sqaure on the board
                        moves[placementIndex] = null;
                    }
                    else if(king.gameBoard.boardGrid[x+i, y+j] != null)
                    {
                        if(king.gameBoard.boardGrid[x + i, y + j].white != king.white)
                        {
                            //valid capture
                            Move move = new Move { moveValue = CAPTURE_PIECE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + j), actor = actor };
                            moves[placementIndex] = move;
                        }
                    }
                    else
                    {
                        //valid move
                        Move move = new Move { moveValue = NON_ESSENTIAL_MOVE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + j), actor = actor };
                        moves[placementIndex] = move;
                    }
                    placementIndex++;
                }
            }
            //shuffle moves
            Random rnd = new Random();
            Move[] shuffledMoves= moves.OrderBy(M => rnd.Next()).ToArray();
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
                        if(king.checkSafe(move.endingSquare.Item1, move.endingSquare.Item2)){
                            bestMove = move;
                        }
                    }
                } 
            }
            return bestMove;
        }
    }

    public class WhitePawnBehavior : Behavior
    {
        private WhitePawnBehavior() { }

        public WhitePawnBehavior(King k)
        {
            king = k;
        }
        public King king;
        //Move values
        private int PROMOTE = 45;
        private int ESCAPE_THREAT = 21;
        private int CAPTURE_PIECE = 20;
        private int NON_ESSENTIAL_MOVE = 10;
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 1;

        //find the king's most preffered move
        public override Move pickMove(int x, int y, Piece actor)
        {
            Move[] moves = new Move[4];//four possible moves
            int placementIndex = 0;
            for(int i = -1; i < 2; ++i)
            {
                if (y < 7 && i != 0 && x + i <= 7 && x + i >= 0 && this.king.gameBoard.boardGrid[x + i, y + 1] != null && this.king.gameBoard.boardGrid[x + i, y + 1].white != actor.white)
                {
                    //a pawn can capture a piece
                    Move move = new Move { moveValue = CAPTURE_PIECE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + 1), actor = actor };
                    moves[placementIndex] = move;
                    ++placementIndex;
                }
            }
            if(y == 1 && king.gameBoard.boardGrid[x, y+2] == null)
            {
                //2 square move
                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y + 2), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
            }
            if(y + 1 < 7 && king.gameBoard.boardGrid[x, y+1] == null)
            {
                //1 square move
                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y + 1), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
            }
            if (y + 1 == 7 && king.gameBoard.boardGrid[x, y + 1] == null)
            {
                //promotion
                Move move = new Move { moveValue = PROMOTE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y + 1), actor = actor };
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
        //rank of the piece (to be multiplied with move values)
        private int PRIORITY_MULTIPLYER = 1;

        //find the king's most preffered move
        public override Move pickMove(int x, int y, Piece actor)
        {
            Move[] moves = new Move[4];//four possible moves
            int placementIndex = 0;
            for (int i = -1; i < 2; ++i)
            {
                if (y > 1 && i != 0 && x + i <= 7 && x + i >= 0 && this.king.gameBoard.boardGrid[x + i, y - 1] != null && this.king.gameBoard.boardGrid[x + i, y - 1].white != actor.white)
                {
                    //a pawn can capture a piece
                    Move move = new Move { moveValue = CAPTURE_PIECE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y - 1), actor = actor };
                    moves[placementIndex] = move;
                    ++placementIndex;
                }
            }
            if (y == 6 && king.gameBoard.boardGrid[x, y - 2] == null)
            {
                //2 square move
                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y - 2), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
            }
            if (y - 1 > 1 && king.gameBoard.boardGrid[x, y - 1] == null)
            {
                //1 square move
                Move move = new Move { moveValue = NON_ESSENTIAL_MOVE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y - 1), actor = actor };
                moves[placementIndex] = move;
                ++placementIndex;
            }
            if (y - 1 == 0 && king.gameBoard.boardGrid[x, y - 1] == null)
            {
                //promotion
                Move move = new Move { moveValue = PROMOTE, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x, y - 1), actor = actor };
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

