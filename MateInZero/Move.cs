using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    internal class Move
    {
        int moveValue; //How valuable the move is percieved to be by the suggesting piece
        string startingSquare; //Where the moving piece is located
        string endingSquare; //Where the moving piece is moving to
        Piece actor; //The piece that wishes to move
    }
}
