using NUnit.Framework;
using CraphModel;
using GraphRepresentation;
using System.Collections.Generic;


namespace GraphRepresentationTest
{
    public class AdjacencyListTest
    {
        private List<Vertex> vertexes;

        private AdjacencyList adList;

        private Vertex vertex;

        [SetUp]
        public void Setup()
        {
            vertex = new Vertex();

            vertexes = new List<Vertex>() { vertex };

            adList = new AdjacencyList(vertexes);
            
        }

        [Test]
        public void AddVertexTest_AddExistVertex_ExceptionExpected()
        {

            var ex = Assert.Throws<System.Exception>(() => adList.AddVertex(vertex));

            Assert.AreEqual(ex.Message, "This vertex is already in the list of adjacencies");

        }

        [Test]
        public void AddNodeTest_CreateLoop_ExceptionExpected()
        {

            var ex = Assert.Throws<System.Exception>(() => adList.AddNode(vertex.Id, vertex.Id, 20));

            Assert.AreEqual(ex.Message, "The starting vertex coincides with the ending vertex");
        }
    }
}