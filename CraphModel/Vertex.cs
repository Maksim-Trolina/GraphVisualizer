using System.Collections.Generic;


namespace CraphModel
{
  
    public class Vertex
    {
     
        public int Id { get; set; }
        public List<Node> Nodes { get; set; }
    }


    public struct Node
    {
    
        public int Weight { get; set; }    
        public int Connectable { get; set; }
    }
}
