using System.Windows.Forms;


namespace Forms
{
    public partial class InputCountVertexForm : Form
    {
        private InputCountBox inputBox;

        private InfoTextLabel infoText;

        private ConfirmButton confirmButton;

        private DrawVertexButton drawVertexButton;

        public MatrixGraph matrixGraph;

        private BackToMenuFromInputButton backToMenuOfInputButton;

        public InputCountVertexForm(StartForm.StartForm startForm)
        {
            InitializeComponent();

            matrixGraph = new MatrixGraph(this);

            inputBox = new InputCountBox(300, 20, 200, 100);
            Controls.Add(inputBox);

            infoText = new InfoTextLabel(300, 30, 200, 80);
            Controls.Add(infoText);

            confirmButton = new ConfirmButton(100, 30, 500, 100, inputBox, matrixGraph);
            Controls.Add(confirmButton);

            backToMenuOfInputButton = new BackToMenuFromInputButton(matrixGraph, startForm, this);
            Controls.Add(backToMenuOfInputButton);

            drawVertexButton = new DrawVertexButton(100, 30, 600, 100, this, matrixGraph, startForm);
            Controls.Add(drawVertexButton);

        }


    }


}
