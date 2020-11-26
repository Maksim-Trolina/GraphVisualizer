﻿using System;

namespace Forms
{
    class BackToMenuFromInputButton : BackButton
    {
        private Forms.InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        private StartForm.StartForm startForm;

        public BackToMenuFromInputButton(MatrixGraph matrixGraph, StartForm.StartForm startForm, 
            InputCountVertexForm inputCountVertexForm, string buttonText = "back to menu") : base(buttonText)
        {

            Text = buttonText;

            Location = new System.Drawing.Point(10, 410);

            this.startForm = startForm;

            this.inputCountVertexForm = inputCountVertexForm;

            this.matrixGraph = matrixGraph;

        }


        public override void ButtonClick(object sender, EventArgs e)
        {

            matrixGraph.DeleteMatrix();

            startForm.Show();

            inputCountVertexForm.Close();
           

        }
    }
}
