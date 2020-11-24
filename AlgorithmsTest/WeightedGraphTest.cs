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

            List<Vertex> path = weightedGraph.FindShortestPath(verticles[0], verticles[2]);

            Assert.AreEqual(null, path);
        }

        [Test]
        public void FindShortestPathTest_SimpleGraph_NullExcepted()
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

            List<Vertex> actual = weightedGraph.FindShortestPath(verticles[0], verticles[4]);

            List<Vertex> expected = new List<Vertex>()
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
                { Id = 4, Nodes = new List<Node>()
                    {
                        new Node() { Weight = 1, Connectable = 3 }
                    }
                },
            };

            for (int i = 0; i < actual.Count; ++i)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }

           
        }
    }
}
