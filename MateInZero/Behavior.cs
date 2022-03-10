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
        //The king does not need a vision pattern since it can see the whole board

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
                    else
                    {
                        //valid move
                        Move move = new Move { moveValue = 0, startingSquare = Tuple.Create<int, int>(x, y), endingSquare = Tuple.Create<int, int>(x + i, y + j), actor = actor };
                        moves[placementIndex] = move;
                    }
                    placementIndex++;
                }
            }
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

        //check if a square is under attack
        //king will not move to/remain on a square if it is under attack
        private bool checkThreats(int x, int y)
        {
            return false;
        }
    }
}

