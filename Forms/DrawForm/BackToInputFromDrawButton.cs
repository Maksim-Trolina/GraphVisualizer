using System;
using System.Collections.Generic;
using GraphModelDraw;
using GraphRepresentation;


namespace Forms.DrawForm
{
    class BackToInputFromDrawButton : BackButton
    {
        private AdjacencyList adjacencyList;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private AdjacencyListPanel adjacencyListPanel;

        private WeightTable weightTable;

        private List<List<CellBox>> matrix;

        private List<List<CellAdjacencyList>> cells;

        private InputCountVertexForm inputCountVertexForm;

        private MatrixGraph matrixGraph;

        public BackToInputFromDrawButton(AdjacencyList adjacencyList, List<VertexDraw> vertexDraws,
            List<EdgeDraw> edgeDraws, StartForm.DrawForm drawForm, AdjacencyListPanel adjacencyListPanel,
            WeightTable weightTable, List<List<CellBox>> matrix, List<List<CellAdjacencyList>> cells,
            InputCountVertexForm inputCountVertexForm, MatrixGraph matrixGraph, string buttonText = "back to matrix") : base(buttonText)
        {

            Text = buttonText;

            Location = new System.Drawing.Point(400, 410);

            this.adjacencyList = adjacencyList;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.drawForm = drawForm;

            this.weightTable = weightTable;

            this.adjacencyListPanel = adjacencyListPanel;

            this.matrix = matrix;

            this.cells = cells;

            this.inputCountVertexForm = inputCountVertexForm;

            this.matrixGraph = matrixGraph;

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
            
            if(matrixGraph != null)
            matrixGraph.DeleteMatrix();

            inputCountVertexForm.Show();

            drawForm.Close();

        }

    }
}
