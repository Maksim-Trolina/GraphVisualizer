using System.Windows.Forms;
using Forms.DrawForm;
using CraphModel;



namespace StartForm
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();

            Graph graph = new Graph();

            Vertex vertex1 = new Vertex();

            graph.Vertexs = new System.Collections.Generic.List<Vertex>(1);
            vertex1.Nodes = new System.Collections.Generic.List<Node>(1);



            vertex1.Nodes.Add(new Node() { Connectable = 10, Weight = 50 });
            vertex1.Id = 27;


            graph.Vertexs.Add(new Vertex() { Nodes = vertex1.Nodes, Id = vertex1.Id });


            SaveButton saveButton = new SaveButton() { graph = graph };


            Controls.Add(saveButton);

        }
    }
}
