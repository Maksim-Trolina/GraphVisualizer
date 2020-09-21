using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CraphModel
{
    [Serializable]

    public class Graph : IGraph
    {
        public List<Vertex> Vertexs { get; set; }
    }

}
