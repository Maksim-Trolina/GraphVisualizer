using CraphModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Serializing
{

    public class SerializeGraph
    {
        public void SaveGraph(Graph Graph, string FilePath)
        {

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Graph));

            using FileStream fs = new FileStream(string.Concat(FilePath, ".json"), FileMode.OpenOrCreate);

            formatter.WriteObject(fs, Graph);

        }
    }
}
