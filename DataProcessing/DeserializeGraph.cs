﻿using CraphModel;
using System.IO;
using System.Runtime.Serialization.Json;


namespace Serializing
{
    public class DeserializeGraph
    {
        public Graph LoadGraph()
        {

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Graph));

            using (FileStream fs = new FileStream("Graphs.json", FileMode.OpenOrCreate))
            {
                
               return (Graph)formatter.ReadObject(fs);

            }
        }

    }
}
