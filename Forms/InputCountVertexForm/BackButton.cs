using System.Windows.Forms;
using System;

namespace Forms
{
    class BackButton : Button
    {
        private MatrixGraph matrixGraph;

        private StartForm.StartForm startForm;

        private InputCountVertexForm inputCountVertexForm;

        public BackButton(int width, int height, int positionX, int positionY, MatrixGraph matrixGraph, 
            StartForm.StartForm startForm, InputCountVertexForm inputCountVertexForm, string buttonText = "back to menu")
        {

            this.Text = buttonText;

            this.Size = new System.Drawing.Size(width, height);

            this.Location = new System.Drawing.Point(positionX, positionY);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);

            Click += new EventHandler(ButtonClick);

            this.matrixGraph = matrixGraph;

            this.startForm = startForm;

            this.inputCountVertexForm = inputCountVertexForm;

        }

        public virtual void ButtonClick(object sender, EventArgs e)
        {
            matrixGraph.DeleteMatrix();

            inputCountVertexForm.Hide();
            startForm.ShowDialog();
            inputCountVertexForm.Close();
        }
    }
}
