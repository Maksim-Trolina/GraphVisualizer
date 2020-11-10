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

        private AdjacencyListButton adListButton;

        public ToolPanel(int positionX, int positionY, WeightTable weightTable, List<EdgeDraw> edgeDraws, AdjacencyList adjacencyList 
            ,StartForm.DrawForm drawForm, AdjacencyListTable adListTable)
        {

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Left;

            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;

            tableButton = new WeightTableButton(20, 20, weightTable);

            cycleButton = new CycleButton(20, 20, adjacencyList, edgeDraws, drawForm);

            adListButton = new AdjacencyListButton(20, 20, adListTable);

            Items.Add(tableButton); 

            Items.Add(new ToolStripSeparator());

            Items.Add(adListButton);

            Items.Add(new ToolStripSeparator());

            Items.Add(cycleButton);

            Items.Add(new ToolStripSeparator());

        }
    }
}
