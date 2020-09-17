﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forms;



namespace StartForm
{
    public partial class StartForm : Form
    {

        StartButton startButton;

        public StartForm()
        {
            InitializeComponent();

            startButton = new StartButton {nextForm = nextForm};

            this.Controls.Add(startButton);
          
        }

        InputCountVertexForm nextForm = new InputCountVertexForm();


    }

}
