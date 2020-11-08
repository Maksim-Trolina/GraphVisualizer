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

            AdjacencyList adjacencyList = converter.ConvertToAdjacencyList(inputCounts);

            Assert.IsTrue(adjacencyList.adjacencyList.Count == 0);

        }

        [Test]
        public void ConvertTest_Matrix_List()
        {
            List<List<InputCountBox>> inputCounts = new List<List<InputCountBox>> { new List<InputCountBox>{ new InputCountBox(0,0,0,0) { Text = "0"}, new InputCountBox(0,0,0,0){Text = "12"} ,new InputCountBox(0, 0, 0, 0) { Text="0"} },
                new List<InputCountBox>{new InputCountBox(0, 0, 0, 0) { Text = "3"},new InputCountBox(0, 0, 0, 0) { Text = "0"},new InputCountBox(0, 0, 0, 0) { Text = "33"} },
                new List<InputCountBox>{new InputCountBox(0, 0, 0, 0) { Text = "0"}, new InputCountBox(0, 0, 0, 0) { Text = "0"},new InputCountBox(0, 0, 0, 0) { Text = "0"} }
                };
            Converter converter = new Converter();

            AdjacencyList adjacencyList = converter.ConvertToAdjacencyList(inputCounts);

            Assert.IsTrue(AreEqualNodes(adjacencyList.adjacencyList[0], new List<CraphModel.Node> { new CraphModel.Node { Connectable = 1, Weight = 12 } })
                && AreEqualNodes(adjacencyList.adjacencyList[1], new List<CraphModel.Node> { new CraphModel.Node { Connectable = 0, Weight = 3 }, new CraphModel.Node { Connectable = 2, Weight = 33 } })
                && AreEqualNodes(adjacencyList.adjacencyList[2], new List<CraphModel.Node>()));
        }

        private bool AreEqualNodes(List<CraphModel.Node> list1 ,List<CraphModel.Node> list2)
        {
            if(list1.Count != list2.Count)
            {
                return false;
            }

            for(int i = 0; i < list1.Count; i++)
            {
                if(list1[i].Connectable!=list2[i].Connectable || list1[i].Weight!= list2[i].Weight)
                {
                    return false;
                }
            }

            return true;
        }
    }
}