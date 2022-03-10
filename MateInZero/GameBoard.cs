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
        private Board board;

        private bool whiteTurn = true;

        public King blackKing;
        public King whiteKing;

        public Piece [,] boardGrid = new Piece[8, 8] { 
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null},
            {null, null, null, null, null, null, null, null}
        };
        
        private GameBoard() { }
        public GameBoard(Board board)
        {
            this.board = board;
            whiteKing = new King(true, this);
            blackKing = new King(false, this);
            this.boardGrid[4, 0] = whiteKing;
            this.boardGrid[4, 7] = blackKing;
        }

        //play the next turn
        public void playTurn()
        {
            if (whiteTurn)
            {
                this.playMove(this.whiteKing.playMove());
                whiteTurn = false;
            }
            else
            {
                this.playMove(this.blackKing.playMove());
                whiteTurn = true;
            }
        }

        public void playMove(Move move)
        {
            if(this.boardGrid[move.endingSquare.Item1, move.endingSquare.Item2] != null)
            {
                //delete the piece since it has been captured
                board.deletePiece(move.actor.name);
            }

            //move piece to new location on the board
            this.boardGrid[move.endingSquare.Item1, move.endingSquare.Item2] = this.boardGrid[move.startingSquare.Item1, move.startingSquare.Item2];
            //set square where the piece used to be to null
            this.boardGrid[move.startingSquare.Item1, move.startingSquare.Item2] = null;
            //update pieces current position
            move.actor.currentPosition = Tuple.Create<int, int>(move.endingSquare.Item1, move.endingSquare.Item2);
            //Make move on visual board
            board.movePiece(move.actor.name, move.endingSquare, move.startingSquare);
        }
    }
}
