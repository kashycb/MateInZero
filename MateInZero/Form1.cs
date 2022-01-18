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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            mainMenuExitBtn.MouseEnter += OnMouseEnterMainMenuExitBtn;
            mainMenuStartBtn.MouseEnter += OnMouseEnterMainMenuStartBtn;
            mainMenuExitBtn.MouseLeave += OnMouseLeaveMainMenuExitBtn;
            mainMenuStartBtn.MouseLeave += OnMouseLeaveMainMenuStartBtn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mainMenuExitBtn_Click(object sender, EventArgs e)
        {

        }

        private void OnMouseEnterMainMenuExitBtn(object sender, EventArgs e) 
        {
            mainMenuExitBtn.BackColor = Color.PaleGreen;
        }
        private void OnMouseEnterMainMenuStartBtn(object sender, EventArgs e)
        {
            mainMenuStartBtn.BackColor = Color.PaleGreen;
        }
        private void OnMouseLeaveMainMenuExitBtn(object sender, EventArgs e)
        {
            mainMenuExitBtn.BackColor = Color.PaleTurquoise;
        }
        private void OnMouseLeaveMainMenuStartBtn(object sender, EventArgs e)
        {
            mainMenuStartBtn.BackColor = Color.PaleTurquoise;
        }
    }
}
