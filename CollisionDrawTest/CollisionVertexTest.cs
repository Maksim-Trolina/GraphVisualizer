using NUnit.Framework;
using CollisionDraw;
using System;
using System.Collections.Generic;
using GraphModelDraw;

namespace CollisionDrawTest
{
    public class CollisionVertexTest
    {
        private List<VertexDraw> vertexDraws;

        private VertexDraw vertexDraw;

        private CollisionVertex collisionVertex;

        [SetUp]
        public void Setup()
        {
            vertexDraws = new List<VertexDraw>();

            collisionVertex = new CollisionVertex();

            float x = 30.5f;
            float y = 20.7f;

            vertexDraw = new VertexDraw(BrushColor.Orange, BrushColor.Green, x, y, (float)VertexParameters.Width, (float)VertexParameters.Height, "", vertexDraws.Count);
        }

        [Test]
        public void IsDrawVertexTest_EmptyList_TrueExpected()
        {
            vertexDraws.Clear();

            bool actual = collisionVertex.IsDrawVertex(vertexDraw, vertexDraws);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsDrawVertexTest_NoCollision_TrueExpected()
        {
            float x = vertexDraw.X + 2 * (float)VertexParameters.Radius + 0.1f;
            float y = vertexDraw.Y;          

            VertexDraw vertexItemList = new VertexDraw(BrushColor.Orange, BrushColor.Green, x, y, (float)VertexParameters.Width 
               , (float)VertexParameters.Height, "", vertexDraws.Count);

            vertexDraws.Add(vertexItemList);

            bool actual = collisionVertex.IsDrawVertex(vertexDraw, vertexDraws);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsDrawVertexTest_IsCollision_FalseExpected()
        {
            float x = vertexDraw.X + 2 * (float)VertexParameters.Radius - 0.1f;
            float y = vertexDraw.Y;

            VertexDraw vertexItemList = new VertexDraw(BrushColor.Orange, BrushColor.Green, x, y, (float)VertexParameters.Width
               , (float)VertexParameters.Height, "", vertexDraws.Count);

            vertexDraws.Add(vertexItemList);

            bool actual = collisionVertex.IsDrawVertex(vertexDraw, vertexDraws);

            Assert.IsFalse(actual);
        }
    }
}