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

            using (FileStream fs = new FileStream("d://Graph1.json", FileMode.OpenOrCreate))
            {

                formatter.WriteObject(fs, this);
               
            }

        }

    }
}
