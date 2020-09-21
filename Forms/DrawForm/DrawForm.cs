using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Forms.DrawForm;

namespace StartForm
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();

            SaveButton saveButton = new SaveButton();

            Controls.Add(saveButton);
        }
    }
}
