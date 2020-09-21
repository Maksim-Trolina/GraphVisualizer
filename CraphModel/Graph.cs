using System.Collections.Generic;
using System.Runtime.Serialization;



namespace CraphModel
{

    [DataContract]
    public class Graph : IGraph
    {
       
        public List<Vertex> Vertexs { get; set; }


    }

}
