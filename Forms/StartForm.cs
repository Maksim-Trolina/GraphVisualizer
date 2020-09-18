using System.Windows.Forms;
using Forms;



namespace StartForm
{
    public partial class StartForm : Form
    {

        private StartButton startButton;
        private InputCountVertexForm nextForm;

        public StartForm()
        {
            InitializeComponent();

            nextForm = new InputCountVertexForm();

            startButton = new StartButton {StartForm = this, NextForm = nextForm};

            Controls.Add(startButton);
            
        }
    }
}
