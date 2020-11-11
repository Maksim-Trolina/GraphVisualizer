﻿using CraphModel;
using System.IO;
using System.Runtime.Serialization.Json;


namespace Serializing
{
    public class DeserializeGraph
    {
        public Graph LoadGraph(string FilePath)
        {

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Graph));

            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {

               return (Graph)formatter.ReadObject(fs);

            }
        }

    }
}
