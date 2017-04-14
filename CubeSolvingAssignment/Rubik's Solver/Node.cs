using System.Linq;

namespace CubeSolvingAssignment
{
    public sealed class Node
    {
        public Cube CubeNode { get; set; }
        public bool IsVisted { get; set; }

        /* Checks if a node is equal to another node by checking 
        that the sequence of the one array matches the other one */
        public bool IsEqual(Node node)
        {
            return CubeNode.Grid.SequenceEqual(node.CubeNode.Grid);
        }
    }
}
