using System.Collections.Generic;
using System.Runtime.Serialization;



namespace CraphModel
{
    [DataContract]
    [KnownType(typeof(Graph))]

    public class Graph : IGraph
    {
        [DataMember]
        public List<Vertex> Vertexs { get; set; }

    }
}
