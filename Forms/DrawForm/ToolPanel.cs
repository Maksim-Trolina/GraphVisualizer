using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using GraphModelDraw;
using GraphRepresentation;

namespace Forms.DrawForm
{
    class ToolPanel : ToolStrip
    {
        private WeightTableButton tableButton;

        private CycleButton cycleButton;

        public ToolPanel(int positionX, int positionY, WeightTable weightTable,List<EdgeDraw> edgeDraws,AdjacencyList adjacencyList)
        {

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Left;

            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;

            tableButton = new WeightTableButton(20, 20, weightTable);

            cycleButton = new CycleButton(20, 20,adjacencyList,edgeDraws);

            Items.Add(tableButton);

            Items.Add(new ToolStripSeparator());

            Items.Add(cycleButton);

            Items.Add(new ToolStripSeparator());

        }
    }
}
