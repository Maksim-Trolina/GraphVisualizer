using System;
using System.Windows.Forms;
using CraphModel;
using Serializing;
using System.Collections.Generic;
using GraphModelDraw;




namespace Forms
{
    class LoadFileButton : Button
    {

        private DeserializeGraph deserializeGraph;
        public Graph LoadGraph { get; set; }

        private StartForm.StartForm startForm;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private List<List<InputCountBox>> matrix;

        private DrawForm.Converter converter;


        public LoadFileButton(StartForm.StartForm startForm)
        {
            Text = "Load file";

            Location = new System.Drawing.Point(350, 220);

            Size = new System.Drawing.Size(100, 50);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            vertexDraws = new List<VertexDraw>();

            this.startForm = startForm;

            edgeDraws = new List<EdgeDraw>();          

            Click += new EventHandler(ButtonClick);

            deserializeGraph = new DeserializeGraph();

            converter = new DrawForm.Converter();

        }
       

        public void ButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                this.Enabled = true;

                LoadGraph = deserializeGraph.LoadGraph(ofd.FileName);

                matrix = converter.ConvertToListListInputCountBox(LoadGraph);

                drawForm = new StartForm.DrawForm(vertexDraws, edgeDraws, matrix);

                startForm.Hide();
                drawForm.ShowDialog();
                startForm.Close();
            }
            
        }

    }
}
