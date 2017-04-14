using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using CubeSolvingAssignment.Graphs;

namespace CubeSolvingAssignment.Solving_Methods
{
    public sealed class MeetMiddle
    {
        public Graph DestinationGraph { get; set; }
        // The graphs which holds all the nodes that the other graphs (Meet Middle Graphs) are searching for

        private bool IsSearching { get; } // Checks if still searching for a connecting node

        // Possible solutions to start searching from (Opposites: WY BG OR / 04 13 25 )
        private readonly Color[] _colorVariation1 = {Color.Green, Color.White, Color.Red, Color.Yellow, Color.Blue,Color.Orange};
        private readonly Color[] _colorVariation2 = {Color.Yellow, Color.Green, Color.Orange, Color.Blue, Color.White,Color.Red};
        private readonly Color[] _colorVariation3 = {Color.Red, Color.Blue, Color.White, Color.Green, Color.Orange,Color.Yellow};
        private readonly Color[] _colorVariation4 = {Color.Blue, Color.Orange, Color.Yellow, Color.Red, Color.Green,Color.White };
        private readonly Color[] _colorVariation5 = {Color.White, Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Green };
        private readonly Color[] _colorVariation6 = { Color.Orange, Color.Yellow, Color.Green, Color.White, Color.Red, Color.Blue };

        private Queue<Color[]> ColorQueue { get; set; }
        private HashSet<MeetMiddleGraph> MeetMiddleGraphs { get; set; } // Set of all the middle graphs
        private HashSet<Node> Nodes { get; set; } // Set of all starting nodes (solved solutions)

        public MeetMiddle(Graph destinationGraph)
        {
            try
            {
                DestinationGraph = destinationGraph;

                IsSearching = true;
                Nodes = new HashSet<Node>();
                ColorQueue = new Queue<Color[]>();
                MeetMiddleGraphs = new HashSet<MeetMiddleGraph>();

                ColorQueue.Enqueue(_colorVariation1);
                ColorQueue.Enqueue(_colorVariation2);
                ColorQueue.Enqueue(_colorVariation3);
                ColorQueue.Enqueue(_colorVariation4);
                ColorQueue.Enqueue(_colorVariation5);
                ColorQueue.Enqueue(_colorVariation6);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Initialize()
        {
            try
            {
                var colorCount = ColorQueue.Count;
                for (int i = 0; i < colorCount; i++)
                {
                    var tmpNode = new Node
                    {
                        CubeNode = new Cube(6, 4, ColorQueue.Dequeue()),
                        IsVisted = false
                    };

                    Nodes.Add(tmpNode);
                }

                for (int i = 0; i < Nodes.Count; i++)
                {
                    var tmpMeetMiddle = new MeetMiddleGraph(Nodes.ToArray()[i])
                    {
                        DestinationGraph = DestinationGraph
                    };

                    MeetMiddleGraphs.Add(tmpMeetMiddle);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Execute()
        {
            try
            {
                var meetMiddleGraphArray = MeetMiddleGraphs.ToArray();

                while (IsSearching)
                {
                    // Excutes the destination graph multiple times (parallel execution)
                    var executeDesitnationGraph =
                        Task.Factory.StartNew(() => DestinationGraph.Execute())
                            .ContinueWith(prevTask => DestinationGraph.Execute())
                            .ContinueWith((prevTask) => DestinationGraph.Execute());
                    Task.WaitAny(executeDesitnationGraph);

                    executeDesitnationGraph =
                        Task.Factory.StartNew(() => DestinationGraph.Execute())
                            .ContinueWith(prevTask => DestinationGraph.Execute())
                            .ContinueWith((prevTask) => DestinationGraph.Execute());
                    Task.WaitAny(executeDesitnationGraph);

                    // If one of the nodes generated is solved break from this loop
                    if (!DestinationGraph.IsGraphUnSolved)
                    {
                        break;
                    }

                    var tmpTask = Task.Factory.StartNew(() => meetMiddleGraphArray[0].Execute());
                    var tmpTask1 = Task.Factory.StartNew(() => meetMiddleGraphArray[1].Execute());
                    var tmpTask2 = Task.Factory.StartNew(() => meetMiddleGraphArray[2].Execute());
                    Task.WaitAll(tmpTask, tmpTask1, tmpTask2);

                    if (!DestinationGraph.IsGraphUnSolved)
                    {
                        break;
                    }

                    var tmpTask4 = Task.Factory.StartNew(() => meetMiddleGraphArray[3].Execute());
                    var tmpTask5 = Task.Factory.StartNew(() => meetMiddleGraphArray[4].Execute());
                    var tmpTask6 = Task.Factory.StartNew(() => meetMiddleGraphArray[5].Execute());
                    Task.WaitAll(tmpTask4, tmpTask5, tmpTask6);

                    if (!DestinationGraph.IsGraphUnSolved)
                    {
                        break;
                    }

                    /*
                    Console.WriteLine(
                        string.Format("first " + " " + DestinationGraph.Nodes.Count() + " " +
                                      meetMiddleGraphArray[0].Nodes.Count() + " " +
                                      meetMiddleGraphArray[1].Nodes.Count() + " " +
                                      meetMiddleGraphArray[5].Nodes.Count() + " " +
                                      meetMiddleGraphArray[2].Nodes.Count() + " " +
                                      meetMiddleGraphArray[3].Nodes.Count() + " " +
                                      meetMiddleGraphArray[4].Nodes.Count()));
                    */

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
