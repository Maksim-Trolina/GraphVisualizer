using System;
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

        public ToolPanel(int positionX, int positionY, WeightTable weightTable)
        {

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Left;

            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;

            tableButton = new WeightTableButton(20, 20, weightTable);

            toolSeparator = new ToolStripSeparator();

            Items.Add(tableButton);

            Items.Add(toolSeparator);

        }
    }
}
