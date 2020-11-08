using Algorithms;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

        [Test]
        public void GetCycleTest_EmptyGraph_EmptyList()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int>(), new List<int>(), new List<int>() };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);
            List<int> cycle;

            unweightedGraph.IsAcyclic();
            cycle = unweightedGraph.GetCycle();

            Assert.IsTrue(cycle.SequenceEqual(new List<int>()));
        }

        [Test]
        public void GetCycleTest_CycleOfTwoVertex_Cycle()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 1, 2 }, new List<int>(), new List<int> { 0, 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);
            List<int> cycle;

            unweightedGraph.IsAcyclic();
            cycle = unweightedGraph.GetCycle();

            Assert.IsTrue(cycle.SequenceEqual(new List<int>() { 0,2,0}));
        }

        [Test]
        public void GetCycleTest_CycleOfFiveVertex_Cycle()
        {
            List<List<int>> graph = new List<List<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 0 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);
            List<int> cycle;

            unweightedGraph.IsAcyclic();
            cycle = unweightedGraph.GetCycle();

            Assert.IsTrue(cycle.SequenceEqual(new List<int>() { 0, 1, 2, 3, 4, 0 }));
        }
    }
}