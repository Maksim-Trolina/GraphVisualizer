using NUnit.Framework;
using CraphModel;
using GraphRepresentation;
using System.Collections.Generic;


namespace GraphRepresentationTest
{
    public class AdjacencyListTest
    {

        [Test]
        public void AddVertexTest_AddExistVertex_ExceptionExpected()
        {

            List<Vertex> verticles = new List<Vertex>();
            Vertex vertex = new Vertex();
            verticles.Add(vertex);
            AdjacencyList adList = new AdjacencyList(verticles);

            var ex = Assert.Throws<System.Exception>(() => adList.AddVertex(vertex));

            Assert.AreEqual(ex.Message, "This vertex is already in the list of adjacencies");

        }

        [Test]
        public void AddNodeTest_CreateLoop_ExceptionExpected()
        {
            List<Vertex> verticles = new List<Vertex>();
            Vertex vertex = new Vertex();
            verticles.Add(vertex);
            AdjacencyList adList = new AdjacencyList(verticles);

            var ex = Assert.Throws<System.Exception>(() => adList.AddNode(vertex, vertex, 20));

            Assert.AreEqual(ex.Message, "The starting vertex coincides with the ending vertex");
        }
    }
}