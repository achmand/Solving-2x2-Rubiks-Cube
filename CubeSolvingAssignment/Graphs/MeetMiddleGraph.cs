using System;
using System.Collections.Generic;
using System.Linq;

namespace CubeSolvingAssignment.Graphs
{
    public sealed class MeetMiddleGraph
    {
        public HashSet<Edge> Edges { get; set; }
        public Graph DestinationGraph { get; set; }
        public Node SolvedNode { get; set; }
        public HashSet<Node> Nodes
        {
            get
            {
                var nodeSet = ReturningNodes;
                return GetNodesFromEdges(ref nodeSet);
            }
        }

        private Node MiddleNode { get; set; }
        private HashSet<Cube> DestinationSet { get; }
        private HashSet<Cube> SourceSet { get; }
        private CubeComparer CubeComparer { get; }
        private HashSet<Node> ReturningNodes { get; }
        
        public MeetMiddleGraph(Node solvedNode)
        {
            SolvedNode = solvedNode;

            ReturningNodes = new HashSet<Node>();
            Edges = new HashSet<Edge>();
            DestinationSet = new HashSet<Cube>();
            SourceSet = new HashSet<Cube>();
            CubeComparer = new CubeComparer();
        }

        // Executes the middle graph (Similiar to the main graph)
        public void Execute()
        {
            try
            {
                var nonVisitedNode = GetNonVistedNode(); // Gets non visted node
                AddAllEdges(nonVisitedNode); // Add all edges to non visted node
                DestinationGraph.IsGraphUnSolved = CheckIfMetInMiddle(); // Check if an unjumbled state was found in the destination graph
                if (DestinationGraph.IsGraphUnSolved) // If graph not solved return
                {
                    return;
                }

                InvertOtherEdges(); // Invert Edges to be able to connect the two edges
                var destinationEdges = DestinationGraph.Edges; 
                destinationEdges.UnionWith(Edges); // Merges the edges together
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Node GetNonVistedNode()
        {
            return Nodes.FirstOrDefault(node => node.IsVisted == false);
        }

        private HashSet<Node> GetNodesFromEdges(ref HashSet<Node> nodes)
        {
            if (Edges.Count > 0)
            {
                foreach (var edge in Edges)
                {
                    if (!nodes.Contains(edge.PrevCube))
                    {
                        nodes.Add(edge.PrevCube);
                    }
                    if (!nodes.Contains(edge.NewCube))
                    {
                        nodes.Add(edge.NewCube);
                    }
                }
            }
            else
            {
                nodes.Add(SolvedNode);
            }
            return nodes;
        }

        private Node NodeExist(Node existNode)
        {
            foreach (var node in Nodes)
            {
                if (node.IsEqual(existNode))
                {
                    return node;
                }
            }
           return null;
        }

        private void AddEdge(Edge edge, ref bool done)
        {
            if (NodeExist(edge.NewCube) != null)
            {
                edge.NewCube = NodeExist(edge.NewCube);
            }
            if (DestinationGraph.NodeExist(edge.NewCube) != null)
            {
                DestinationGraph.IsGraphUnSolved = false;
                done = true;
            }
            Edges.Add(edge);
        }

        private void AddAllEdges(Node node)
        {
            var countFaces = Enum.GetValues(typeof(Face)).Length;
            var countTurns = Enum.GetValues(typeof(Turn)).Length;
            var done = false;

            for (int i = 0; i < countFaces; i++)
            {
                if (done)
                {
                    break;

                }
                for (int x = 0; x < countTurns; x++)
                {
                    var tmpNode = new Node { CubeNode = node.CubeNode.RotateCube((Face)i, (Turn)x) };
                    var edge = new Edge(node, tmpNode, (Face)i, (Turn)x, 1);

                    AddEdge(edge, ref done);
                    if (done)
                    {
                        break;
                    }
                    node.IsVisted = true;
                }
            }
        }

        private bool CheckIfMetInMiddle()
        {
            // This is the most optimal way that I found to check for matching nodes
            var destSet = DestinationSet;
            var sourceSet = SourceSet;
            destSet.UnionWith(DestinationGraph.Nodes.Select(s => s.CubeNode)); 
            sourceSet.UnionWith(Nodes.Select(f => f.CubeNode));

            var intersect = destSet.Intersect(sourceSet, CubeComparer).Any(); // Intersects both sets to check for any matched

            if (!intersect)
            {
                return true;
            }
            var all = DestinationGraph.Nodes.Where(b => Nodes.Any(a => a.IsEqual(b))); // Checks which node matched
            var sourceNode = all.First(); // Gets the matching node
            if (sourceNode == null)
            {
                return true;
            }
            MiddleNode = sourceNode; // Set the middle propety to the matching node
            DestinationGraph.SolvedNode = SolvedNode; // Set the destination solved node to this node
            return false;
        }

        // Inverts edges 
        private void InvertOtherEdges()
        {
            foreach (var edge in Edges)
            {
                var prevCube = edge.PrevCube;
                edge.PrevCube = edge.NewCube;
                edge.NewCube = prevCube;
                edge.Turn = (edge.Turn == Turn.Clockwise) ? Turn.AntiClockwise : Turn.Clockwise;
            }
        }
    }
}
