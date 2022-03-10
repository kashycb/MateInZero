using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateInZero
{
    public class Move
    {

        public int moveValue; //How valuable the move is percieved to be by the suggesting piece
        public Tuple<int, int> startingSquare; //Where the moving piece is located
        public Tuple<int, int> endingSquare; //Where the moving piece is moving to
        public Piece actor; //The piece that wishes to move

        /*
        public Move(int value, Tuple<int, int> startingCoords, Tuple<int, int> endingCoords, Piece actor)
        {
            this.moveValue = value;
            this.startingSquare = startingCoords;
            this.endingSquare = endingCoords;
            this.actor = actor;
        }
        */
    }
}
