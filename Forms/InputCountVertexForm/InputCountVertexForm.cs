﻿using StartForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public partial class InputCountVertexForm : Form
    {
        private InputCountBox inputBox;

        private InfoTextLabel infoText;

        private ConfirmButton confirmButton;

        private DrawVertexButton drawVertexButton;

        private StartForm.DrawForm drawForm;

        public InputCountVertexForm()
        {
            InitializeComponent();

            inputBox = new InputCountBox(300, 20, 200, 100);
            Controls.Add(inputBox);

            infoText = new InfoTextLabel(300, 30, 200, 80);
            Controls.Add(infoText);

            confirmButton = new ConfirmButton(100, 30, 500, 100, inputBox, this);
            Controls.Add(confirmButton);

            drawForm = new StartForm.DrawForm();

            drawVertexButton = new DrawVertexButton(100, 30, 600, 100, this, drawForm);
            Controls.Add(drawVertexButton);
        }

        
    }


}
