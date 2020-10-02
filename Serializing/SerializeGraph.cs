using CraphModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Serializing
{

    public class SerializeGraph
    {
        public void SaveGraph(Graph Graph)
        {

            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(int));

            using FileStream fs = new FileStream("d://Graph23.json", FileMode.OpenOrCreate);

            formatter.WriteObject(fs, Graph);

        }
    }
}
