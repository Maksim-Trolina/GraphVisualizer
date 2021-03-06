using NUnit.Framework;
using CraphModel;
using System.Collections.Generic;
using Serializing;



namespace SerializingTest
{
    public class DeserializeGraphTest
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

            serializeGraph.SaveGraph(graph, "TestSeving");

        }

        [Test]
        public void SerializationEdgeWeightTest_Weight_AreEqual()
        {

            int expected = 228;
            int actual = deserializeGraph.LoadGraph("TestSeving.json").Vertexs[0].Nodes[0].Weight;          

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SerializationGraphIdTest_Id_AreEqual()
        {

            int expected = 42;
            int actual = deserializeGraph.LoadGraph("TestSeving.json").Vertexs[0].Id;
          
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SerializationEdgeConnectableTest_Connectable_AreEqual()
        {

            int expected = 17;
            int actual = deserializeGraph.LoadGraph("TestSeving.json").Vertexs[0].Nodes[1].Connectable;

            Assert.AreEqual(expected, actual);
        }



    }
}