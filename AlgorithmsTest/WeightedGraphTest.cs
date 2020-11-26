using Algorithms;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using GraphRepresentation;
using CraphModel;
using System;

namespace AlgorithmsTest
{
    public class WeightedGraphTest
    {
        [Test]
        public void FindShortestPathTest_IsolatedVertex_NullExpected()
        {
            List<Vertex> verticles = new List<Vertex>()
            {
                new Vertex() { Id = 0, Nodes = new List<Node>() { new Node() { Weight = 1, Connectable = 1 } } },

                new Vertex() { Id = 1, Nodes = new List<Node>() { new Node() { Weight = 3, Connectable = 0 } } },

                new Vertex() { Id = 2 }
            };

            AdjacencyList adjacencyList = new AdjacencyList(verticles);

            WeightedGraph weightedGraph = new WeightedGraph(adjacencyList);

            List<int> actual = weightedGraph.FindShortestPath(verticles[0].Id, verticles[2].Id);

            Assert.Null(actual);
        }

        [Test]
        public void FindShortestPathTest_SimpleGraph_PathExpected()
        {
            List<Vertex> verticles = new List<Vertex>()
            {
                new Vertex() 
                { Id = 0, Nodes = new List<Node>() 
                    { 
                         new Node() { Weight = 3, Connectable = 4 }
                        , new Node() { Weight = 1, Connectable = 1 }
                        , new Node() { Weight = 2, Connectable = 2} 
                    } 
                },

                new Vertex() 
                { Id = 1, Nodes = new List<Node>() 
                    { 
                        new Node() { Weight = 1, Connectable = 4 }
                        ,new Node() { Weight = 2, Connectable = 3} 
                    } 
                },

                new Vertex() 
                { Id = 2, Nodes = new List<Node>()
                    {
                        new Node() { Weight = 1, Connectable = 3 } 
                    }
                },

                new Vertex() { Id = 3, Nodes = new List<Node>()},

                new Vertex() 
                { Id = 4, Nodes = new List<Node>()
                    {
                        new Node() { Weight = 1, Connectable = 3 } 
                    }
                },
            };

            AdjacencyList adjacencyList = new AdjacencyList(verticles);

            WeightedGraph weightedGraph = new WeightedGraph(adjacencyList);

            List<int> actual = weightedGraph.FindShortestPath(verticles[0].Id, verticles[4].Id);

            List<int> expected = new List<int> { 0, 1, 4 };

            for (int i = 0; i < actual.Count; ++i)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [Test]
        public void FindShortestPath_StartEqualsEnd_PathExpected()
        {
            List<Vertex> verticles = new List<Vertex>()
            {
                new Vertex() { Id = 0, Nodes = new List<Node>() { new Node() { Weight = 1, Connectable = 1 } } },

                new Vertex() { Id = 1, Nodes = new List<Node>() { new Node() { Weight = 3, Connectable = 0 } } },

                new Vertex() { Id = 2 }
            };

            AdjacencyList adjacencyList = new AdjacencyList(verticles);

            WeightedGraph weightedGraph = new WeightedGraph(adjacencyList);

            List<int> actual = weightedGraph.FindShortestPath(verticles[0].Id, verticles[0].Id);

            List<int> expected = new List<int> { 0 };

            for (int i = 0; i < actual.Count; ++i)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
