using System.Windows.Forms;
using Forms;
using System.Drawing;
using System;



namespace StartForm
{
    public partial class StartForm : Form
    {

        private StartButton startButton;

        private LoadFileButton loadFileButton;

        public StartForm()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            Text = "GraphVizualizer / Menu";

            this.BackColor = Color.DarkGray;

            startButton = new StartButton(this);

            loadFileButton = new LoadFileButton(this);
           
            Controls.Add(startButton);

            Controls.Add(loadFileButton);


        }

    }
}
