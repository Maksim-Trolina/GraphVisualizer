using System.Windows.Forms;
using GraphModelDraw;
using GraphRepresentation;
using System.Collections.Generic;
using System;


namespace Forms.DrawForm
{
    class DeleteAllButton : ToolStripButton
    {

        private AdjacencyList adjacencyList;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private AdjacencyListPanel adjacencyListPanel;

        private WeightTable weightTable;

        private List<List<CellBox>> matrix;

        public DeleteAllButton(int width, int height, AdjacencyList adjacencyList, List<VertexDraw> vertexDraws, 
            List<EdgeDraw> edgeDraws, StartForm.DrawForm drawForm, AdjacencyListPanel adjacencyListPanel, WeightTable weightTable, List<List<CellBox>> matrix)
        {

            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Text = "Delete all";

            Click += new EventHandler(ButtonClick);

            this.adjacencyList = adjacencyList;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.drawForm = drawForm;

            this.weightTable = weightTable;

            this.adjacencyListPanel = adjacencyListPanel;

            this.matrix = matrix;
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            
            adjacencyList.adjacencyList.Clear();
            vertexDraws.Clear();
            edgeDraws.Clear();
            matrix.Clear();

            adjacencyListPanel.Controls.Clear();
            weightTable.Controls.Clear();

            drawForm.Refresh();
        }
    }
}
