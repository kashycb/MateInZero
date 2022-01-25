using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//GameBoard.cs
//Represent a chess board via a grid
namespace MateInZero
{
    public class GameBoard
    {
        private Piece BlackKing;
        private Piece WhiteKing;
        private Piece [,] boardGrid = new Piece [7,7];
    }
}
