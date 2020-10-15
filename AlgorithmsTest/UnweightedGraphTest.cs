using Algorithms;
using NUnit.Framework;
using System.Collections.Generic;

namespace AlgorithmsTest
{
    public class UnweightedGraphTest
    {

        [Test]
        public void IsAcyclicTest_CycleOfAllVertex_False()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 2 }, new List<int> { 0 }, new List<int> { 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            bool actual = unweightedGraph.IsAcyclic();

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsAcyclicTest_Acyclic_True()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 1, 2 }, new List<int>(), new List<int> { 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            bool actual = unweightedGraph.IsAcyclic();

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsAcyclicTest_Empty_True()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>() };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            bool actual = unweightedGraph.IsAcyclic();

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsAcyclicTest_CycleOfTwoVertex_False()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 1, 2 }, new List<int>(), new List<int> { 0, 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            bool actual = unweightedGraph.IsAcyclic();

            Assert.IsFalse(actual);
        }
    }
}