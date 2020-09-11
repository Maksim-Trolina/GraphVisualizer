using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forms;



namespace StartForm
{
    public partial class StartForm : Form
    {

        private StartButton menuButton = new StartButton();

        private int buttonWidth = 100, buttonHeight = 50;
      
        public StartForm()
        {
            InitializeComponent();

            menuButton.ButtonInitialization(this, "Matrix", this.ClientRectangle.Width / 2 - buttonWidth, this.ClientRectangle.Height / 2 - buttonHeight, buttonWidth, buttonHeight);

        }

    }

}
