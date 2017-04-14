using System;
using System.Collections.Generic;
using System.Linq;
using CubeSolvingAssignment.Shortest_Routes;
using CubeSolvingAssignment.Solving_Methods;

namespace CubeSolvingAssignment.Graphs
{
    public enum ShortestRoute
    {
        BellmanFord,
        Dijkstra
    }

    public enum SolvingMethod
    {
        Normal,
        MeetInMiddle
    }

    public sealed class GraphSettings
    {
        public SolvingMethod SolvingMethodSetting { get; set; }
        public ShortestRoute ShortestRouteSetting { get; set; }
    }

    public sealed class Graph
    {
        public HashSet<Edge> Edges { get; set; }
        public Node RootCube { get; set; }
        public bool IsGraphUnSolved { get; set; }
        public Node SolvedNode { get; set; }

        public HashSet<Node> Nodes
        {
            get
            {
                var result = GetNodesFromEdges();
                return result;
            }
        }

        private GraphSettings Settings { get; }

        public Graph(Node rootCube, GraphSettings settings)
        {
            try
            {
                RootCube = rootCube;
                RootCube.IsVisted = false;
                Edges = new HashSet<Edge>();
                IsGraphUnSolved = true;
                Settings = settings;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Creates graph and calling the required method/s until the graph is solved
        public void CreateGraph()
        {
            try
            {
                var solvingMethod = Settings.SolvingMethodSetting; // Get the specified solving method setting

                if (solvingMethod == SolvingMethod.Normal) // Normal Mode
                {
                    while (IsGraphUnSolved)
                    {
                        Execute(); // Executes normal mode
                    }
                }

                if (solvingMethod != SolvingMethod.MeetInMiddle)
                {
                    return;
                }

                // Meet In Middle Mode
                var meetMiddle = new MeetMiddle(this);
                meetMiddle.Initialize(); // Init meet middle object
                meetMiddle.Execute(); // Executes meet middle object
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Execute()
        {
            var node = GetNonVistedNode(); // Get non visted node 
            AddAllEdges(node); // Add all edges for that none visted node
        }

        // Add all edges from a non visted node
        private void AddAllEdges(Node node)
        {
            var countFaces = Enum.GetValues(typeof (Face)).Length; // Gets enum face length
            var countTurns = Enum.GetValues(typeof (Turn)).Length; // Gets enum turn length 

            // Iterate 
            for (int i = 0; i < countFaces; i++)
            {
                for (int x = 0; x < countTurns; x++)
                {
                    if (!IsGraphUnSolved) // If graph is solved break
                    {
                        break;
                    }

                    var tmpNode = new Node {CubeNode = node.CubeNode.RotateCube((Face) i, (Turn) x)}; // New node for each face and turn
                    var edge = new Edge(node, tmpNode, (Face) i, (Turn) x, 1); // New edge from the non-visted node to the new node
                    AddEdge(edge); // Adds the edge
                    node.IsVisted = true; // Make node visted 
                    if (!edge.NewCube.CubeNode.IsSolved()) // If new cube is not solved 
                    {
                        continue; // Countinue loop
                    }
                    SolvedNode = edge.NewCube; // Make solved cube the new cube which is solved
                    IsGraphUnSolved = false; // Make graph is solved
                    break; // Break from loop
                }
            }
        }

        // Returns the nodes from edges
        private HashSet<Node> GetNodesFromEdges()
        {
            var nodes = new HashSet<Node>();
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
                nodes.Add(RootCube);
            }

            return nodes;
        }

        private Node GetNonVistedNode()
        {
            return Nodes.FirstOrDefault(node => node.IsVisted == false);
        }

        public Node NodeExist(Node existNode)
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

        private void AddEdge(Edge edge)
        {
            if (NodeExist(edge.NewCube) != null) // Check if node exists before adding the edge 
            {
                edge.NewCube = NodeExist(edge.NewCube); // If it exists use that reference 
            }
            Edges.Add(edge);
        }


        private Node IsSolved()
        {
            return Nodes.FirstOrDefault(node => node.CubeNode.IsSolved());
        }

        // Get the shortest solution according to the specified route settings
        public List<Edge> GetSolution()
        {
            try
            {
                var shortestRoute = Settings.ShortestRouteSetting;
                if (shortestRoute == ShortestRoute.BellmanFord)
                {
                    var bellmanFord = new BellmanFord(this);
                    return bellmanFord.GetPath(RootCube, IsSolved());
                }

                var dijkstra = new Dijkstra(this);
                dijkstra.Execute(RootCube);
                return dijkstra.GetPath(SolvedNode);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
