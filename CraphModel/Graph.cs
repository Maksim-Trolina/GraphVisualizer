using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace CraphModel
{

    [DataContract]
    [KnownType(typeof(Graph))]

    public class Graph : IGraph
    {
        [DataMember]
        public List<Vertex> Vertexs { get; set; }

        public void SaveGraph()
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(int));

            Vertexs = new List<Vertex>();

            Vertexs.Add(new Vertex() { Id = 4 });

            Vertexs.Add(new Vertex() { Id = 6 });

            using (FileStream fs = new FileStream("Graph1.json", FileMode.OpenOrCreate))
            {

                formatter.WriteObject(fs, this);
               
            }

        }

    }
}
