﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartForm
{
    public partial class Form1 : Form
    {
        private Button startButton;
        public Form1()
        {
            InitializeComponent();

            startButton = new Button();

            startButton.Bounds = new Rectangle(10, 10, 75, 25);

            Controls.Add(startButton);
        }

    }

}
