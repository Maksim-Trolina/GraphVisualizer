using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms;
using CraphModel;
using GraphRepresentation;
using NUnit.Framework;

namespace AlgorithmsTest
{
    [TestFixture]
    public class ConverterTest
    {
        private Converter converter;
        [SetUp]
        public void Setup()
        {
            converter = new Converter();
        }

        [Test]
        public void ConvertToSimpleGraphTest_Null_EmptyGraph()
        {
            AdjacencyList adjacencyList = null;

            List<List<int>> graph = converter.ConvertToSimpleGraph(adjacencyList);

            Assert.IsTrue(graph.Count == 0);
        }

        [Test]
        public void ConvertToSimpleGrapgTest_ThreeVertexList_GraphThreeVertex()
        {
            List<Vertex> vertices = new List<Vertex> { new Vertex { Id = 1,Nodes = new List<Node> { new Node { Connectable = 0, Weight = 12 }, new Node { Connectable = 2, Weight = 10 } } },
                new Vertex{Id = 0,Nodes = new List<Node>{new Node { Connectable = 2,Weight = 5} }},
                new Vertex{Id = 2,Nodes = new List<Node>() } };
            AdjacencyList adjacencyList = new AdjacencyList(vertices);

            List<List<int>> graph = converter.ConvertToSimpleGraph(adjacencyList);

            Assert.IsTrue(graph[0].SequenceEqual(new List<int> { 2 }) &&
                graph[1].SequenceEqual(new List<int> { 0, 2 }) && graph[2].SequenceEqual(new List<int>()));
        }
    }
}
