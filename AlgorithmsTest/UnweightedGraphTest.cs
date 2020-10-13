using Algorithms;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsTest
{
    public class UnweightedGraphTest
    {
        private UnweightedGraph unweightedGraph;
        [SetUp]
        public void Setup()
        {
   
        }

        [Test]
        public void Test1()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 2 }, new List<int> { 0 }, new List<int> { 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);
            Assert.IsFalse(unweightedGraph.IsAcyclic());
        }

        [Test]
        public void Test2()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 1, 2 }, new List<int>(), new List<int> { 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);
            Assert.IsTrue(unweightedGraph.IsAcyclic());
        }
    }
}