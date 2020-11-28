using System;
using System.Drawing;

namespace Forms
{
    class BackToMenuFromInputButton : BackButton
    {
        private Forms.InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        public BackToMenuFromInputButton(MatrixGraph matrixGraph, 
            InputCountVertexForm inputCountVertexForm, string buttonText = "Menu") : base(buttonText)
        {
            ForeColor = Color.Black;

            this.BackColor = Color.Orange;

            Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

            FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            Text = buttonText;

            Location = new System.Drawing.Point(10, 410);

            this.inputCountVertexForm = inputCountVertexForm;

            this.matrixGraph = matrixGraph;
        }


        public override void ButtonClick(object sender, EventArgs e)
        {
            matrixGraph.DeleteMatrix();

            StartForm.StartForm startForm = new StartForm.StartForm();

            inputCountVertexForm.Hide();

            startForm.ShowDialog();

            inputCountVertexForm.Close();  
        }
    }
}
