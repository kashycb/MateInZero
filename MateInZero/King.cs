using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MateInZero
{
    public class King : Piece
    {
        //remove deafault constructor
        private King(){ }
        
        public GameBoard gameBoard;

        //keep an array of subbordinate pieces
        public Piece[] pieces = new Piece[15];
        public King(bool white, GameBoard board)
        {
            gameBoard = board;
            if (white)
            {
                this.currentPosition = Tuple.Create<int, int>(4, 0);
                this.name = "White-King";
                this.white = true;
                pieces[0] = new WhitePawn(gameBoard, 'A', this);
                pieces[1] = new WhitePawn(gameBoard, 'B', this);
                pieces[2] = new WhitePawn(gameBoard, 'C', this);
                pieces[3] = new WhitePawn(gameBoard, 'D', this);
                pieces[4] = new WhitePawn(gameBoard, 'E', this);
                pieces[5] = new WhitePawn(gameBoard, 'F', this);
                pieces[6] = new WhitePawn(gameBoard, 'G', this);
                pieces[7] = new WhitePawn(gameBoard, 'H', this);
            }
            else
            {
                this.currentPosition = Tuple.Create<int, int>(4, 7);
                this.name = "Black-King";
                this.white = false;
                pieces[0] = new BlackPawn(gameBoard, 'A', this);
                pieces[1] = new BlackPawn(gameBoard, 'B', this);
                pieces[2] = new BlackPawn(gameBoard, 'C', this);
                pieces[3] = new BlackPawn(gameBoard, 'D', this);
                pieces[4] = new BlackPawn(gameBoard, 'E', this);
                pieces[5] = new BlackPawn(gameBoard, 'F', this);
                pieces[6] = new BlackPawn(gameBoard, 'G', this);
                pieces[7] = new BlackPawn(gameBoard, 'H', this);
            }
            this.behavior = new KingBehavior(this);
            
        }

        public void deletePiece(string pieceName)
        {
            for(int i = 0; i < 15; ++i)
            {
                Piece p = pieces[i];
                if (p != null && p.name == pieceName)
                {
                    pieces[i] = null;
                    Console.WriteLine("Deleted" + pieceName);
                    return;
                }
                Console.WriteLine("No piece deleted");
            }
        }
        public Move[] suggestedMoves = new Move[16];

        //Check to see if a square is under threat
        public bool checkSafe(int x, int y)
        {
            //check that there is no king threatening a square
            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;
                    //validate
                    if (x + i < 0 || x + i > 7 || y + j < 0 || y + j > 7)
                    {
                        //skip invalid square
                        continue;
                    }
                    if (gameBoard.boardGrid[x + i, y + j] != null)
                    {
                        Piece piece = gameBoard.boardGrid[x + i, y + j];
                        Console.WriteLine(piece);
                        if(piece.name == "Black-King" || piece.name == "White-King")
                        {
                            //ignore yourself
                            if (piece.name == this.name)
                                continue;
                            //only accept a move that is safe
                            return false;
                        }
                    }
                }
            }

            //Check if a pawn threatening a square
            Regex rgx = new Regex("White -[a - zA - Z] + -Pawn");
            if (this.white == false) {
                for (int i = -1; i < 2; i += 2)
                {
                    if (x + i < 0 || x + i > 7 || y - 1 < 0)
                    {
                        //skip invalid square
                        continue;
                    }
                    Piece piece = gameBoard.boardGrid[x + i, y - 1];
                    if (piece != null)
                    {
                        if(piece.white != this.white)
                            return false;
                    }
                }
            }
            rgx = new Regex("Black -[a - zA - Z] + -Pawn");
            if (this.white)
            {
                for (int i = -1; i < 2; i += 2)
                {
                    if (x + i < 0 || x + i > 7 || y + 1 > 7)
                    {
                        //skip invalid square
                        continue;
                    }
                    Piece piece = gameBoard.boardGrid[x + i, y + 1];
                    if (piece != null)
                    {
                        if (piece.white != this.white)
                            return false;
                    }
                }
            }

            return true;
        }

        public override void suggestMove()
        {
            //pick a move for the king
            Move pickedMove = pickMove(this);

            //Console.WriteLine("Picked move: " + pickedMove.endingSquare);
            for (int i = 0; i < suggestedMoves.Length; i++)
                if (suggestedMoves[i] == null)
                {
                    suggestedMoves[i] = pickedMove;
                    break;
                }
        }

        public Move playMove()
        {
            //get all moves from other pieces
            foreach (Piece piece in pieces)
            {
                if(piece != null)
                    piece.suggestMove();
            }
            //get own move
            this.suggestMove();

            //pick the best move and play it if it does not threaten the king.
            Move bestMove = null;
            foreach (Move move in suggestedMoves)
            {
                if (move == null)
                    continue;
                if(bestMove == null || move.moveValue > bestMove.moveValue)
                {

                    //check if the move is safe
                    if(checkSafe(move.endingSquare.Item1, move.endingSquare.Item2))
                    {
                        //only accept the move if it is safe
                        bestMove = move;
                    }
                }
                Console.WriteLine("Suggested move:" + move.endingSquare + ',' + move.actor);
            }
            Console.WriteLine("Best move: " + bestMove.endingSquare + ',' + bestMove.actor);
            //clear suggested moves for next turn
            Array.Clear(this.suggestedMoves, 0, 16);
            return bestMove;
        }
    }
}
