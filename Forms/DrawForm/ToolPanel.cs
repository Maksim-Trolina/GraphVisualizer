﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class ToolPanel : ToolStrip
    {
        private WeightTableButton tableButton;

        private ToolStripSeparator toolSeparator;

<<<<<<< HEAD
<<<<<<< HEAD
        public ToolPanel(int positionX, int positionY, WeightTable weightTable)
=======
        public ToolPanel(int positionX, int positionY)
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
=======
        public ToolPanel(int positionX, int positionY)
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
        {

            Location = new System.Drawing.Point(positionX, positionY);

<<<<<<< HEAD
<<<<<<< HEAD
            Dock = DockStyle.Left;

            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;

            tableButton = new WeightTableButton(20, 20, weightTable);
=======
=======
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
            Dock = DockStyle.None;

            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;

            tableButton = new WeightTableButton(20, 20);
<<<<<<< HEAD
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
=======
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba

            toolSeparator = new ToolStripSeparator();

            Items.Add(tableButton);

            Items.Add(toolSeparator);

        }
    }
}
