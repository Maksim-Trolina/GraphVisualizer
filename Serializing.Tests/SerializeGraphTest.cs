using NUnit.Framework;
using CraphModel;
using System.Collections.Generic;
using System;

namespace Serializing.Tests
{
    public class Tests
    {
        private Graph graph;
        private Vertex vertex;
        private SerializeGraph serializeGraph;

        [SetUp]
        public void Setup()
        {

            graph = new Graph();
            vertex = new Vertex();

            graph.Vertexs = new List<Vertex>(1);
            vertex.Nodes = new List<Node>(1);

            vertex.Nodes.Add(new Node() { Weight = 10, Connectable = 20 });
            graph.Vertexs.Add(new Vertex() { Nodes = vertex.Nodes, Id = 42 });

            serializeGraph = new SerializeGraph();
        }

        [Test]
        public void Test1()
        {
           
         

            

        }
    }
}