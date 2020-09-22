using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System;



namespace CraphModel
{

    [Serializable]
    public class Graph : IGraph
    {
       
        public List<Vertex> Vertexs { get; set; }


        public void SaveGraph()
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(int));

            using (FileStream fs = new FileStream("Graph.json", FileMode.OpenOrCreate))
            {
                // сериализация (сохранение объекта в поток) 

                formatter.WriteObject(fs, this);

            }

        }

    }

    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }


        public void SaveBook()
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Book));

            using (FileStream fs = new FileStream("Book.json", FileMode.OpenOrCreate))
            {
                // сериализация (сохранение объекта в поток) 

                formatter.WriteObject(fs, this);

            }

        }
    }

}
