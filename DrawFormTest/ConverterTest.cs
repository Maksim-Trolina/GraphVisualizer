using System.Collections.Generic;
using Forms;
using Forms.DrawForm;
using GraphRepresentation;
using NUnit.Framework;

namespace DrawFormTest
{
    public class ConverterTest
    {
        [Test]
        public void ConvertTest_MatrixNull_EmptyList()
        {
            List<List<InputCountBox>> inputCounts = null;
            Converter converter = new Converter();

            AdjacencyList adjacencyList = converter.Convert(inputCounts);

            Assert.IsTrue(adjacencyList.adjacencyList.Count == 0);

        }

        //[Test]
        //public void ConvertTest_Matrix_List()
        //{
        //    List<List<InputCountBox>> inputCounts = new List<List<InputCountBox>> { new List<InputCountBox>{ new InputCountBox(0,0,0,0) { Text = "0"}, new InputCountBox(0,0,0,0){Text = "12"} ,new InputCountBox(0, 0, 0, 0) { Text="0"} },
        //        new List<InputCountBox>{new InputCountBox(0, 0, 0, 0) { Text = "3"},new InputCountBox(0, 0, 0, 0) { Text = "0"},new InputCountBox(0, 0, 0, 0) { Text = "33"} },
        //        new List<InputCountBox>{new InputCountBox(0, 0, 0, 0) { Text = "0"}, new InputCountBox(0, 0, 0, 0) { Text = "0"},new InputCountBox(0, 0, 0, 0) { Text = "0"} }
        //        };
        //    Converter converter = new Converter();

        //    AdjacencyList adjacencyList = converter.Convert(inputCounts);

        //    Assert.
        //}
    }
}