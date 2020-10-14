using System.Windows.Forms;
using Forms;


namespace StartForm
{
    public partial class StartForm : Form
    {

        private StartButton startButton;
        private InputCountVertexForm nextFormStartButton;
        private LoadFileButton loadFileButton;

        public StartForm()
        {
            InitializeComponent();

            nextFormStartButton = new InputCountVertexForm();

            startButton = new StartButton {StartForm = this, NextForm = nextFormStartButton};

            loadFileButton = new LoadFileButton(this);
           
            Controls.Add(startButton);

            Controls.Add(loadFileButton);

            
        }   

    }
}
