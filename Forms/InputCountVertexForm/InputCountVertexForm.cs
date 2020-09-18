using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public partial class InputCountVertexForm : Form
    {
        private InputCountBox inputBox;
        private InfoTextLabel infoText;
        private ConfirmButton confirmButton;

        public InputCountVertexForm()
        {
            InitializeComponent();

            inputBox = new InputCountBox(300, 20, 200, 100);
            Controls.Add(inputBox);

            infoText = new InfoTextLabel(300, 30, 200, 80);
            Controls.Add(infoText);

            confirmButton = new ConfirmButton(100, 30, 300, 300);
            Controls.Add(confirmButton);
        }
    }
       
    
}
