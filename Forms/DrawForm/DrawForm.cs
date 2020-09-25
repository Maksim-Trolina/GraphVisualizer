using System.Windows.Forms;
using Forms.DrawForm;
using CraphModel;



namespace StartForm
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();

            Graph graph = new Graph();

            SaveButton saveButton = new SaveButton() {graph = graph};

            Controls.Add(saveButton);

        }
    }
}
