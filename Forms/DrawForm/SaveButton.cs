using System;
using System.Windows.Forms;
using CraphModel;
using Serializing;
using System.Collections.Generic;
using GraphRepresentation;

namespace Forms.DrawForm
{
    class SaveButton : Button
    {
        private AdjacencyList adjacencyList;

        private SerializeGraph serializeGraph;

        private Converter converter;

        public SaveButton(AdjacencyList adjacencyList)
        {

            Text = "Save that shit";

            Location = new System.Drawing.Point(630, 400);

            Size = new System.Drawing.Size(150, 30);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);

            this.adjacencyList = adjacencyList;

            serializeGraph = new SerializeGraph();

            converter = new Converter();

        }


        public void ButtonClick(object sender, EventArgs e)
        {

            serializeGraph.SaveGraph(converter.ConvertToGraph(adjacencyList));


        }
    }
}
