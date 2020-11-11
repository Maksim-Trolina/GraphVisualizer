using System;
using System.Windows.Forms;
using CraphModel;
using Serializing;
using System.Collections.Generic;
using GraphRepresentation;
using System.IO;

namespace Forms.DrawForm
{
    class SaveButton : Button
    {
        private AdjacencyList adjacencyList;

        private SerializeGraph serializeGraph;

        private Converter converter;


        public SaveButton(AdjacencyList adjacencyList)
        {

            Text = "Save that graph";

            Location = new System.Drawing.Point(350, 400);

            Size = new System.Drawing.Size(150, 30);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);         

            serializeGraph = new SerializeGraph();

            converter = new Converter();

            this.adjacencyList = adjacencyList;

        }


        public void ButtonClick(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Path.GetFullPath(sfd.FileName);

               // adjacencyList = converter.ConvertToAdjacencyList(matrix);

                serializeGraph.SaveGraph(converter.ConvertToGraph(adjacencyList), Path.GetFullPath(sfd.FileName));

            }

          
        }
    }
}
