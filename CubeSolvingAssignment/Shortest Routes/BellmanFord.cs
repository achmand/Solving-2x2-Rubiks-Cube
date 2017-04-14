using System.Collections.Generic;
using System.Linq;
using CubeSolvingAssignment.Graphs;

namespace CubeSolvingAssignment.Shortest_Routes
{
    public sealed class BellmanFord
    {
        private List<Node> Nodes { get; }
        private List<Edge> Edges { get; }
        private Edge[] Predecessor { get; set; }
        private List<Edge> Path { get; set; }

        public BellmanFord(Graph graph)
        {
            Nodes = new List<Node>(graph.Nodes);
            Edges = new List<Edge>(graph.Edges);
            
        }

        public List<Edge> GetPath(Node rootNode, Node target)
        {
            var nodeCount = Nodes.Count;
            var distance = new int[nodeCount];
            Predecessor = new Edge[nodeCount];

            for (int i = 1; i < nodeCount; i++)
            {
                distance[i] = int.MaxValue;
            }

            /* Reference:  https://www.quora.com/What-are-some-tips-tricks-and-gotchas-when-using-the-Bellman-Ford-algorithm-for-graphs
            If you know that the longest acyclic path in the graph between any two nodes is no more than x edges,
            then you don't need to run |V|−1 iterations of the algorithm. You just need to run BF for x iterations.
            */
            for (int j = 0; j < Edges.Count; j++)
            {
                var edge = Edges.ToArray()[j];
                if ((distance[IndexOf(edge.PrevCube)] + edge.Weight) < distance[IndexOf(edge.NewCube)])
                {
                    distance[IndexOf(edge.NewCube)] = (distance[IndexOf(edge.PrevCube)] + edge.Weight);
                    Predecessor[IndexOf(edge.NewCube)] = edge;
                }
            }

            Path = new List<Edge>();

            return FindPath(target, rootNode);
        }

        private List<Edge> FindPath(Node target , Node rootNode)
        {
            var destIndex = IndexOf(target);
            Edge predEdge;
            do
            {
                predEdge = Predecessor[destIndex];
                Path.Add(predEdge);
                destIndex = IndexOf(predEdge.PrevCube);

            } while (!predEdge.PrevCube.IsEqual(rootNode));

            Path.Reverse();
            return Path;
        }

        private int IndexOf(Node node)
        {
            return Nodes.ToList().IndexOf(node);
        }
    }
}