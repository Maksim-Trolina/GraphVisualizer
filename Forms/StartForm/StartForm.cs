using System.Windows.Forms;
using Forms;


namespace StartForm
{
    public partial class StartForm : Form
    {

        private StartButton startButton;
        private LoadFileButton loadFileButton;

        public StartForm()
        {
            InitializeComponent();

            startButton = new StartButton(this);

            loadFileButton = new LoadFileButton(this);
           
            Controls.Add(startButton);

            Controls.Add(loadFileButton);

            
        }   

    }
}
