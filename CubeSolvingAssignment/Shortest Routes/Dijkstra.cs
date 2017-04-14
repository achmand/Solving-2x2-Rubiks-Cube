using System.Collections.Generic;
using CubeSolvingAssignment.Graphs;

namespace CubeSolvingAssignment.Shortest_Routes
{
    // Reference http://www.vogella.com/tutorials/JavaAlgorithmsDijkstra/article.html (Altered Some Code)
    public sealed class Dijkstra
    {
        private List<Node> Nodes { get; set; }
        private List<Edge> Edges { get; }
        private List<Node> SettledNodes { get; set; }
        private List<Node> UnSettledNodes { get; set; }
        private Dictionary<Node, Node> Predecessors { get; set; }
        private Dictionary<Node, int> Distance { get; set; }

        public Dijkstra(Graph graph)
        {
            Nodes = new List<Node>(graph.Nodes);
            Edges = new List<Edge>(graph.Edges);
        }

        public void Execute(Node sourceNode)
        {
            SettledNodes = new List<Node>();
            UnSettledNodes = new List<Node>();
            Distance = new Dictionary<Node, int>();
            Predecessors = new Dictionary<Node, Node>();
            Distance.Add(sourceNode, 0);
            UnSettledNodes.Add(sourceNode);
            while (UnSettledNodes.Count > 0)
            {
                var node = GetMinimum(UnSettledNodes);
                SettledNodes.Add(node);
                UnSettledNodes.Remove(node);
                FindShortestDistance(node);
            }
        }

        private void FindShortestDistance(Node node)
        {
            var adjNodes = GetNeighbors(node);
            foreach (var target in adjNodes)
            {
                if (GetShortestDistance(target) > GetShortestDistance(node) + GetDistance(node, target))
                {
                    Distance.Add(target, GetShortestDistance(node) + GetDistance(node, target));
                    Predecessors.Add(target, node);
                    UnSettledNodes.Add(target);
                }
            }
        }

        private int GetDistance(Node node, Node target)
        {
            foreach (var edge in Edges)
            {
                if (edge.PrevCube.IsEqual(node) && edge.NewCube.IsEqual(target))
                {
                    return edge.Weight;
                }
            }
            return 0;
        }

        private IEnumerable<Node> GetNeighbors(Node node)
        {
            var neighbors = new List<Node>();
            foreach (var edge in Edges)
            {
                if (edge.PrevCube.IsEqual(node) && !IsSettled(edge.NewCube))
                {
                    neighbors.Add(edge.NewCube);
                }
            }
            return neighbors;
        }
        private Node GetMinimum(IEnumerable<Node> nodes)
        {
            Node minimumNode = null;
            foreach (var n in nodes)
            {
                if (minimumNode == null)
                {
                    minimumNode = n;
                }
                else
                {
                    if (GetShortestDistance(n) < GetShortestDistance(minimumNode))
                    {
                        minimumNode = n;
                    }
                }
            }
            return minimumNode;
        }

        private bool IsSettled(Node node)
        {
            return SettledNodes.Contains(node);
        }

        private int GetShortestDistance(Node destination)
        {
            var containsKey = Distance.ContainsKey(destination);
            if (!containsKey)
            {
                return int.MaxValue;
            }
            var value = Distance[destination];
            return value;
        }

        private Edge GetEdgeFromNodes(Node oldCube, Node newCube)
        {
            foreach (var e in Edges)
            {
                if (e.PrevCube.IsEqual(oldCube) && e.NewCube.IsEqual(newCube))
                {
                    return e;
                }
            }
            return null;
        }

        // Changed the get path method
        public List<Edge> GetPath(Node target)
        {
            var path = new List<Edge>();
            var node = target;
            var containsKey = Distance.ContainsKey(node);
            if (!containsKey)
            {
                return null;
            }

            path.Add(GetEdgeFromNodes(Predecessors[node], node));
            while (Predecessors[node] != null)
            {

                node = Predecessors[node];
                var isFinished = Predecessors.ContainsKey(node);
                if (!isFinished)
                {
                    break;
                }
                path.Add(GetEdgeFromNodes(Predecessors[node], node));
            }
            path.Reverse();
            return path;
        }

    }
}
