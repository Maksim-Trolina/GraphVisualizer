using System;
using System.Windows.Forms;
using CraphModel;
using Serializing;



namespace Forms
{
    class LoadFileButton : Button
    {

        public LoadFileButton()
        {
            Text = "Load file";

            Location = new System.Drawing.Point(350, 220);

            Size = new System.Drawing.Size(100, 50);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);

        }

        private DeserializeGraph deserializeGraph = new DeserializeGraph();

        public Graph LoadGraph { get; set; }

        public StartForm.StartForm StartForm;

        public InputCountVertexForm NextForm;

        public void ButtonClick(object sender, EventArgs e)
        {

            LoadGraph = deserializeGraph.LoadGraph();

            StartForm.Hide();
            NextForm.ShowDialog();
            StartForm.Close();

        }

    }
}
