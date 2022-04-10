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

        public int numMoves;

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
            //White
            this.boardGrid[4, 0] = whiteKing;
            this.boardGrid[0, 1] = whiteKing.pieces[0];
            this.boardGrid[1, 1] = whiteKing.pieces[1];
            this.boardGrid[2, 1] = whiteKing.pieces[2];
            this.boardGrid[3, 1] = whiteKing.pieces[3];
            this.boardGrid[4, 1] = whiteKing.pieces[4];
            this.boardGrid[5, 1] = whiteKing.pieces[5];
            this.boardGrid[6, 1] = whiteKing.pieces[6];
            this.boardGrid[7, 1] = whiteKing.pieces[7];
            this.boardGrid[1, 0] = whiteKing.pieces[8];
            this.boardGrid[6, 0] = whiteKing.pieces[9];
            this.boardGrid[0, 0] = whiteKing.pieces[10];
            this.boardGrid[7, 0] = whiteKing.pieces[11];
            this.boardGrid[2, 0] = whiteKing.pieces[12];
            this.boardGrid[5, 0] = whiteKing.pieces[13];
            this.boardGrid[3, 0] = whiteKing.pieces[14];
            this.boardGrid[4, 0] = whiteKing;
            //Black
            this.boardGrid[0, 6] = blackKing.pieces[0];
            this.boardGrid[1, 6] = blackKing.pieces[1];
            this.boardGrid[2, 6] = blackKing.pieces[2];
            this.boardGrid[3, 6] = blackKing.pieces[3];
            this.boardGrid[4, 6] = blackKing.pieces[4];
            this.boardGrid[5, 6] = blackKing.pieces[5];
            this.boardGrid[6, 6] = blackKing.pieces[6];
            this.boardGrid[7, 6] = blackKing.pieces[7];
            this.boardGrid[1, 7] = blackKing.pieces[8];
            this.boardGrid[6, 7] = blackKing.pieces[9];
            this.boardGrid[0, 7] = blackKing.pieces[10];
            this.boardGrid[7, 7] = blackKing.pieces[11];
            this.boardGrid[2, 7] = blackKing.pieces[12];
            this.boardGrid[5, 7] = blackKing.pieces[13];
            this.boardGrid[3, 7] = blackKing.pieces[14];
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
                numMoves++;
            }
        }

        public void playMove(Move move)
        {
            //handle castling rights
            if(move.actor.type == "Rook")
            {
                ((Rook)move.actor).castleRights = false;
            }

            if(move.actor.type == "King" && Math.Abs(move.startingSquare.Item1 - move.endingSquare.Item1) == 1)
            {
                ((King)move.actor).castleRights = false;
            }
            if(move.actor.type == "King" && Math.Abs(move.startingSquare.Item1 - move.endingSquare.Item1) > 1)
            {
                //king has castled need to move the rook
                if(move.endingSquare.Item1 == 6 && move.endingSquare.Item2 == 0)//white short castle
                {
                    Move rookMove = new Move { moveValue = 0, startingSquare = Tuple.Create<int, int>(7, 0), endingSquare = Tuple.Create<int, int>(5, 0), actor = this.boardGrid[7,0]};
                    this.playMove(rookMove);
                }
                else if(move.endingSquare.Item1 == 6 && move.endingSquare.Item2 == 7)//black short castle
                {
                    Move rookMove = new Move { moveValue = 0, startingSquare = Tuple.Create<int, int>(7, 7), endingSquare = Tuple.Create<int, int>(5, 7), actor = this.boardGrid[7, 7]};
                    this.playMove(rookMove);
                }
                else if(move.endingSquare.Item1 == 2 && move.endingSquare.Item2 == 0)//white long castle
                {
                    Move rookMove = new Move { moveValue = 0, startingSquare = Tuple.Create<int, int>(0, 0), endingSquare = Tuple.Create<int, int>(3, 0), actor = this.boardGrid[0, 0] };
                    this.playMove(rookMove);
                }
                else if(move.endingSquare.Item1 == 2 && move.endingSquare.Item2 == 7)//black long castle
                {
                    Move rookMove = new Move { moveValue = 0, startingSquare = Tuple.Create<int, int>(0, 7), endingSquare = Tuple.Create<int, int>(3, 7), actor = this.boardGrid[0, 7] };
                    this.playMove(rookMove);
                }
            }

            //handle en passant 
            if(move.actor.type == "Pawn" && Math.Abs(move.startingSquare.Item2 - move.endingSquare.Item2) > 1)
            {
                if (move.actor.white)
                    ((WhitePawn)move.actor).enPassantTarget = true;
                else
                    ((BlackPawn)move.actor).enPassantTarget = true;
            }
            

            Piece p = this.boardGrid[move.endingSquare.Item1, move.endingSquare.Item2];
            if (p != null)
            {
                //delete the piece since it has been captured
                //delete visually
                board.deletePiece(p.name);
                //delete the piece from the kings array
                p.king.deletePiece(p.name);
                //delete from boardGrid
                this.boardGrid[move.endingSquare.Item1, move.endingSquare.Item2] = null;
            }

            //move piece to new location on the board
            this.boardGrid[move.endingSquare.Item1, move.endingSquare.Item2] = this.boardGrid[move.startingSquare.Item1, move.startingSquare.Item2];
            //set square where the piece used to be to null
            this.boardGrid[move.startingSquare.Item1, move.startingSquare.Item2] = null;
            //update pieces current position
            move.actor.currentPosition = Tuple.Create<int, int>(move.endingSquare.Item1, move.endingSquare.Item2);
            //Make move on visual board
            board.movePiece(move.actor.name, move.endingSquare, move.startingSquare);

            //handle en passant capture
            if (move.actor.type == "Pawn" && move.endingSquare.Item2 == move.startingSquare.Item2)
            {
                int i = -1;
                if (move.actor.white)
                    i = 1;

                Move pawnMove = new Move { moveValue = 0, startingSquare = Tuple.Create<int, int>(move.endingSquare.Item1, move.endingSquare.Item2), endingSquare = Tuple.Create<int, int>(move.endingSquare.Item1, move.endingSquare.Item2 + i), actor = this.boardGrid[move.endingSquare.Item1, move.endingSquare.Item2] };
                this.playMove(pawnMove);
            }

            //handle promotion
            if(move.actor.type == "Pawn" && (move.endingSquare.Item2 == 7 || move.endingSquare.Item2 == 0))//promote the pawn
            {
                board.promotePawn(move.actor.name, move.actor.white);
                move.actor.type = "Queen";
                move.actor.behavior = new QueenBehavior(move.actor.king);
            }
        }
    }
}
