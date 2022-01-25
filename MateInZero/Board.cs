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
    }
}
