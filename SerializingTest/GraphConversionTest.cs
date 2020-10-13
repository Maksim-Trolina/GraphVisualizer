using NUnit.Framework;
using CraphModel;
using System.Collections.Generic;
using Serializing;



namespace SerializingTest
{
    public class GraphConversionTest
    {


        private Graph graph;
        private Vertex vertex;
        private SerializeGraph serializeGraph;
        private DeserializeGraph deserializeGraph;
       

        [SetUp]
        public void Setup()
        {
            graph = new Graph();
            vertex = new Vertex();
            serializeGraph = new SerializeGraph();
            deserializeGraph = new DeserializeGraph();

            graph.Vertexs = new List<Vertex>(1);
            vertex.Nodes = new List<Node>(2);

            vertex.Nodes.Add(new Node() { Weight = 228, Connectable = 20 });
            vertex.Nodes.Add(new Node() { Weight = 14, Connectable = 17 });

            graph.Vertexs.Add(new Vertex() { Nodes = vertex.Nodes, Id = 42 });

        }

        [Test]
        public void SerializationEdgeWeight_Weight_228return()
        {
            serializeGraph.SaveGraph(graph);

            int expected = 228;
            int actual = deserializeGraph.LoadGraph().Vertexs[0].Nodes[0].Weight;          

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SerializationGraphId_Id_42return()
        {
            serializeGraph.SaveGraph(graph);

            int expected = 42;
            int actual = deserializeGraph.LoadGraph().Vertexs[0].Id;
          
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SerializationEdgeConnectable_Connectable_17return()
        {
            serializeGraph.SaveGraph(graph);

            int expected = 17;
            int actual = deserializeGraph.LoadGraph().Vertexs[0].Nodes[1].Connectable;

            Assert.AreEqual(expected, actual);
        }



    }
}