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

            unweightedGraph.IsAcyclic();
            List<int> cycle = unweightedGraph.GetCycle();

            Assert.IsTrue(cycle.SequenceEqual(new List<int>()));
        }

        [Test]
        public void GetCycleTest_CycleOfTwoVertex_Cycle()
        {
            List<List<int>> graph = new List<List<int>>() { new List<int> { 1, 2 }, new List<int>(), new List<int> { 0, 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            unweightedGraph.IsAcyclic();
            List<int> cycle = unweightedGraph.GetCycle();

            Assert.IsTrue(cycle.SequenceEqual(new List<int>() { 0,2,0}));
        }

        [Test]
        public void GetCycleTest_CycleOfFiveVertex_Cycle()
        {
            List<List<int>> graph = new List<List<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int> { 3 }, new List<int> { 4 }, new List<int> { 0 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            unweightedGraph.IsAcyclic();
            List<int> cycle = unweightedGraph.GetCycle();

            Assert.IsTrue(cycle.SequenceEqual(new List<int>() { 0, 1, 2, 3, 4, 0 }));
        }

        [Test]
        public void GetCyclesTest_GraphWithTwoCycle_TwoCycle()
        {
            List<List<int>> graph = new List<List<int>> { new List<int> { 1, 4 }, new List<int> { 2, 3 }, new List<int> { 0 }, new List<int> { 0, }, new List<int> { 1 } };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            List<List<int>> cycles = unweightedGraph.GetCycles();

            bool isTrueCount = cycles.Count == 2;

            Assert.IsTrue(isTrueCount && cycles[0].SequenceEqual(new List<int> { 0, 1, 2, 0 }) && cycles[1].SequenceEqual(new List<int> { 0, 4, 1, 3, 0 }));
        }

        [Test]
        public void GetCyclesTest_GraphWithoutCycles_ZeroCycle()
        {
            List<List<int>> graph = new List<List<int>> { new List<int> { 1 }, new List<int> { 2 }, new List<int>() };
            UnweightedGraph unweightedGraph = new UnweightedGraph(graph);

            List<List<int>> cycles = unweightedGraph.GetCycles();

            bool isTrueCount = cycles.Count == 0;

            Assert.IsTrue(isTrueCount);
            
        }
    }
}