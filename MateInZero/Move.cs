using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class Move
    {
        int moveValue; //How valuable the move is percieved to be by the suggesting piece
        Tuple<int, int> startingSquare; //Where the moving piece is located
        Tuple<int, int> endingSquare; //Where the moving piece is moving to
        Piece actor; //The piece that wishes to move
    }
}
