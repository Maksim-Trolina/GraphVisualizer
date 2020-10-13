using System.Windows.Forms;
using Forms;



namespace StartForm
{
    public partial class StartForm : Form
    {

        private StartButton startButton;
        private InputCountVertexForm nextForm;
        private LoadFileButton loadFileButton;

        public StartForm()
        {
            InitializeComponent();

            nextForm = new InputCountVertexForm();

            startButton = new StartButton {StartForm = this, NextForm = nextForm};

            loadFileButton = new LoadFileButton {StartForm = this, NextForm = nextForm };

            Controls.Add(startButton);

            Controls.Add(loadFileButton);

        }
    }
}
