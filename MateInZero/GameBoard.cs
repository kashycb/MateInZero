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
        private bool whiteTurn = true;

        public King BlackKing;
        public King WhiteKing;

        private Piece [,] boardGrid = new Piece[8, 8] { 
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null}
        };
        
        public GameBoard()
        {
            this.boardGrid[0, 4] = WhiteKing;
            this.boardGrid[7, 4] = BlackKing;
        }

        //play the next turn
        public void playtTurn()
        {
            if (whiteTurn)
            {
                this.WhiteKing.playMove();
            }
            else
            {
                this.BlackKing.playMove();
            }
        }
    }
}
