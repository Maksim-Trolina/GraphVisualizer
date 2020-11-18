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

        private AdjacencyListPanelButton adListButton;

        private SaveButton saveButton;

        private DeleteAllButton deleteAllButton;

        private SaveWeightButton saveWeightButton;

        public ToolPanel(int positionX, int positionY, WeightTable weightTable, List<EdgeDraw> edgeDraws, AdjacencyList adjacencyList 
            ,StartForm.DrawForm drawForm, AdjacencyListPanel adListPanel, List<VertexDraw> vertexDraws, List<List<CellBox>> matrix)
        {

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Left;

            LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;

            tableButton = new WeightTableButton(20, 20, weightTable, adListPanel);

            cycleButton = new CycleButton(20, 20, adjacencyList, edgeDraws, drawForm);

            adListButton = new AdjacencyListPanelButton(20, 20, adListPanel, weightTable);

            saveButton = new SaveButton(20, 20, adjacencyList);

            deleteAllButton = new DeleteAllButton(20, 20, adjacencyList, vertexDraws, edgeDraws, drawForm, adListPanel, weightTable, matrix);

            saveWeightButton = new SaveWeightButton(20, 20, adjacencyList, matrix, weightTable, adListPanel);

            Items.Add(tableButton); 

            Items.Add(new ToolStripSeparator());

            Items.Add(adListButton);

            Items.Add(new ToolStripSeparator());

            Items.Add(cycleButton);

            Items.Add(new ToolStripSeparator());

            Items.Add(saveButton);

            Items.Add(new ToolStripSeparator());

            Items.Add(deleteAllButton);

            Items.Add(new ToolStripSeparator());

            Items.Add(saveWeightButton);

            Items.Add(new ToolStripSeparator());
        }
    }
}
