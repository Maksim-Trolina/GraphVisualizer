using System;
using System.Collections.Generic;
using GraphModelDraw;
using GraphRepresentation;


namespace Forms.DrawForm
{
    class BackToMenuFromDrawButton : BackButton
    {
        private AdjacencyList adjacencyList;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private AdjacencyListPanel adjacencyListPanel;

        private WeightTable weightTable;

        private List<List<CellBox>> matrix;

        private List<List<CellAdjacencyList>> cells;

        private StartForm.StartForm startForm;

        public BackToMenuFromDrawButton(AdjacencyList adjacencyList, List<VertexDraw> vertexDraws, 
            List<EdgeDraw> edgeDraws, StartForm.DrawForm drawForm, AdjacencyListPanel adjacencyListPanel, 
            WeightTable weightTable, List<List<CellBox>> matrix, List<List<CellAdjacencyList>> cells, 
            StartForm.StartForm startForm, string buttonText = "back to menu") : base(buttonText)
        {

            Text = buttonText;

            Location = new System.Drawing.Point(300, 410);

            this.adjacencyList = adjacencyList;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.drawForm = drawForm;

            this.weightTable = weightTable;

            this.adjacencyListPanel = adjacencyListPanel;

            this.matrix = matrix;

            this.cells = cells;

            this.startForm = startForm;

    }

        public override void ButtonClick(object sender, EventArgs e)
        {

            adjacencyList.adjacencyList.Clear();
            vertexDraws.Clear();
            edgeDraws.Clear();
            matrix.Clear();
            cells.Clear();

            adjacencyListPanel.Controls.Clear();
            weightTable.Controls.Clear();

            startForm.Show();
            drawForm.Hide();
            
        }

    }
}
