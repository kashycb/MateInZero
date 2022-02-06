using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateInZero
{
    public partial class Board : Form
    {
        private const int SQAURESIZEP = 70;

        private Form CallingForm = null;

        public Board(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public Board()
        {
            InitializeComponent();
            InitializePictureBoxes();
            nextMoveButton.MouseEnter += OnMouseEnterNextMoveButton;
            nextMoveButton.MouseLeave += OnMouseLeaveNextMoveButton;
            this.FormClosing += new FormClosingEventHandler(Board_FormClosing);
        }

        private void movePiece(PictureBox piece, string newLocation, string currentLocation) 
        {
            //get coordinates from string parameters
            Tuple<int, int> newCoords = SquareToCoords(newLocation);
            Tuple<int, int> oldCoords = SquareToCoords(currentLocation);

            //calculate move amount
            int lateralMoveAmount = -1 * (newCoords.Item1 - oldCoords.Item1) * SQAURESIZEP;
            int verticalMoveAmount = (newCoords.Item2 - oldCoords.Item2) * SQAURESIZEP;

            //move piece
            piece.Location = new Point(piece.Location.X + lateralMoveAmount, piece.Location.Y + verticalMoveAmount);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Board_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if (this.CallingForm != null)
                this.CallingForm.Show();
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {

        }

        private void InitializePictureBoxes() 
        {
            //Black pawns
            pbBPA.Parent = pbBoard;
            pbBPB.Parent = pbBoard;
            pbBPC.Parent = pbBoard;
            pbBPD.Parent = pbBoard;
            pbBPE.Parent = pbBoard;
            pbBPF.Parent = pbBoard;
            pbBPG.Parent = pbBoard;
            pbBPH.Parent = pbBoard;
            //Black pieces
            pbBRA.Parent = pbBoard;
            pbBRH.Parent = pbBoard;
            pbBKB.Parent = pbBoard;
            pbBKG.Parent = pbBoard;
            pbBBC.Parent = pbBoard;
            pbBBF.Parent = pbBoard;
            pbBQ.Parent = pbBoard;
            pbBK.Parent = pbBoard;
            //White pawns
            pbWPA.Parent = pbBoard;
            pbWPB.Parent = pbBoard;
            pbWPC.Parent = pbBoard;
            pbWPD.Parent = pbBoard;
            pbWPE.Parent = pbBoard;
            pbWPF.Parent = pbBoard;
            pbWPG.Parent = pbBoard;
            pbWPH.Parent = pbBoard;
            //White pieces
            pbWRA.Parent = pbBoard;
            pbWRH.Parent = pbBoard;
            pbWKB.Parent = pbBoard;
            pbWKG.Parent = pbBoard;
            pbWBC.Parent = pbBoard;
            pbWBF.Parent = pbBoard;
            pbWQ.Parent = pbBoard;
            pbWK.Parent = pbBoard;
        }

        private void OnMouseEnterNextMoveButton(object sender, EventArgs e)
        {
            nextMoveButton.BackColor = Color.Honeydew;
        }
        private void OnMouseLeaveNextMoveButton(object sender, EventArgs e)
        {
            nextMoveButton.BackColor = Color.MediumSpringGreen;
        }

        private Tuple<int, int> SquareToCoords(string square) 
        {
            var lettermap = new Dictionary<char, int> {
                {'a', 0},{'b', 1},{'c', 2},{'d', 3},{'e', 4},{'f', 5},{'g', 6},{'h', 7},
            };
            //check to make sure string format is good
            Debug.Assert(square.Length == 2, "Square name should be 2 characters");
            Debug.Assert(Char.IsLetter(square[0]), "First character of square should be a letter");
            Debug.Assert(Char.IsDigit(square[1]), "First character of square should be a digit");
            //convert to tuple of ints and adjust for off-by-1
            int result;
            lettermap.TryGetValue(Char.ToLower(square[0]), out result);
            return Tuple.Create(result, (int)square[1] - 49);
        }

        private void nextMoveButton_Click(object sender, EventArgs e)
        {
            //Pass logic to gameBoard
        }
    }
}
