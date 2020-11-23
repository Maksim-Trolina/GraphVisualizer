using StartForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;

namespace Forms
{
    public partial class InputCountVertexForm : Form
    {
        private InputCountBox inputBox;

        private InfoTextLabel infoText;

        private ConfirmButton confirmButton;

        private DrawVertexButton drawVertexButton;

        private MatrixGraph matrixGraph;

        private BackToMenuOfInputButton backToMenuOfInputButton;

        public InputCountVertexForm(StartForm.StartForm startForm)
        {
            InitializeComponent();

            matrixGraph = new MatrixGraph(this);

            inputBox = new InputCountBox(300, 20, 200, 100);
            Controls.Add(inputBox);

            infoText = new InfoTextLabel(300, 30, 200, 80);
            Controls.Add(infoText);

            confirmButton = new ConfirmButton(100, 30, 500, 100, inputBox, this, matrixGraph);
            Controls.Add(confirmButton);

            backToMenuOfInputButton = new BackToMenuOfInputButton(matrixGraph, startForm, this);
            Controls.Add(backToMenuOfInputButton);

            drawVertexButton = new DrawVertexButton(100, 30, 600, 100, this, matrixGraph, startForm);
            Controls.Add(drawVertexButton);

            this.FormClosed += InputCountVertexForm_FormClosed;

        }

        private void InputCountVertexForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }


    }


}
