using System;
using System.Windows.Forms;
using CraphModel;
using Serializing;
using System.Collections.Generic;


namespace Forms.DrawForm
{
    class SaveButton : Button
    {
        public SaveButton()
        {

            Text = "Save that shit";

            Location = new System.Drawing.Point(630, 400);

            Size = new System.Drawing.Size(150, 30);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);

            Graph = new Graph();

        }

        public Graph Graph { get; set; }

        public void ButtonClick(object sender, EventArgs e)
        {
            Graph graph = new Graph();
            Vertex vertex = new Vertex();

            graph.Vertexs = new List<Vertex>(1);
            vertex.Nodes = new List<Node>(1);

            vertex.Nodes.Add(new Node() { Weight = 10, Connectable = 20 });
            graph.Vertexs.Add(new Vertex() { Nodes = vertex.Nodes, Id = 42 });

            SerializeGraph serializeGraph = new SerializeGraph();
            serializeGraph.SaveGraph(graph);

        }
    }
}
