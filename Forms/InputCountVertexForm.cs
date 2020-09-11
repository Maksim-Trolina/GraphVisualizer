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

        public InputCountVertexForm()
        {
            InitializeComponent();
            inputBox = new InputCountBox();
            Controls.Add(inputBox);
            
        }
    }
       
    
}
