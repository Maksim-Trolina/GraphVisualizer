using System.Windows.Forms;
using System.Drawing;


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

        private MatrixWeightTablePanel matrixPanel;

        public InputCountVertexForm(StartForm.StartForm startForm)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            Text = "GraphVizualizer / Matrix";

            this.BackColor = Color.DarkGray;

            matrixPanel = new MatrixWeightTablePanel(350, 290, Width / 2 - 190, 155);
            
            matrixGraph = new MatrixGraph(matrixPanel);

            inputBox = new InputCountBox(300, 20, 200, 100);
            Controls.Add(inputBox);

            infoText = new InfoTextLabel(300, 30, 200, 80);
            Controls.Add(infoText);

            confirmButton = new ConfirmButton(100, 30, 500, 100, inputBox, matrixGraph);
            Controls.Add(confirmButton);

            backToMenuOfInputButton = new BackToMenuFromInputButton(matrixGraph, this);
            Controls.Add(backToMenuOfInputButton);

            drawVertexButton = new DrawVertexButton(100, 30, 600, 100, this, matrixGraph, startForm);
            Controls.Add(drawVertexButton);

            Controls.Add(matrixPanel);



        }


    }


}
