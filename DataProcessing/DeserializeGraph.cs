using CraphModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;

namespace Serializing
{
    public class DeserializeGraph
    {
        private Graph graph;

        public Graph LoadGraph(string FilePath)
        {        
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Graph));

            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                try
                {
                    graph = (Graph)formatter.ReadObject(fs);
                }
                catch
                {
                    graph = new Graph();
                    graph.Vertexs = new List<Vertex>();
                    formatter.WriteObject(fs, graph);
                }

                return graph;
            }
        }

    }
}
