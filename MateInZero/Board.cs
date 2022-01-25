using System;
using System.Collections.Generic;
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
        private Form CallingForm = null;

        public Board(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public Board()
        {
            InitializeComponent();
            initializePictureBoxes();
            this.FormClosing += new FormClosingEventHandler(Board_FormClosing);
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

        private void initializePictureBoxes() 
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
    }
}
