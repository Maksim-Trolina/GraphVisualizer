using System;
using System.Collections.Generic;
using System.Text;

namespace CraphModel
{
    class Vertex
    {
        public List<Node> nodes { get; set; }
    }

    internal struct Node
    {   
       public int Weight { get; set; }

       public int Connectable { get; set; }
    }
}
