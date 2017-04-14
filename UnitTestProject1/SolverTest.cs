using CubeSolvingAssignment;
using CubeSolvingAssignment.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public sealed class SolverTest
    {
        [TestMethod]
        public void TestSolvedCube()
        {
            var cube = new Cube(6, 4);
            var notSolved = cube.RotateCube(Face.Top, Turn.AntiClockwise);

            Assert.IsTrue(cube.IsSolved());
            Assert.IsFalse(notSolved.IsSolved());
        }

        [TestMethod]
        public void TestNodeIsEqual()
        {
            var cube0 = new Cube(6, 4);
            var node0 = new Node { CubeNode = cube0 };
            var cube1 = cube0.RotateCube(Face.Top, Turn.AntiClockwise);
            var node1 = new Node { CubeNode = cube1 };
            var cube2 = new Cube(6, 4);
            var node2 = new Node { CubeNode = cube2 };

            Assert.IsTrue(node0.IsEqual(node2));
            Assert.IsFalse(node1.IsEqual(node0));
        }

        [TestMethod]
        public void TestBellmanFord()
        {
            // Testing Section E -> Question 1
            var cube = new Cube(6, 4);
            var cube0 = cube.RotateCube(Face.Right, Turn.Clockwise);
            var cube1 = cube0.RotateCube(Face.Front, Turn.Clockwise);
            var rootNode = new Node {CubeNode = cube1};
            var graphSettings = new GraphSettings
            {
                SolvingMethodSetting = SolvingMethod.Normal,
                ShortestRouteSetting = ShortestRoute.BellmanFord
            };
            var graph = new Graph(rootNode, graphSettings);
            graph.CreateGraph();
            var solution = graph.GetSolution();

            var check = solution.Count == 2; // We know it should be two

            if (solution[0].Turn != Turn.AntiClockwise || solution[0].Face != Face.Front) // One should be F AntiCW
            {
                check = false;
            }

            if (solution[1].Face == Face.Left || solution[1].Face == Face.Right) // It should be left or right
            {
                check = true;
            }

            if (solution[1].Turn != Turn.AntiClockwise) 
            {
                check = false;
            }
            
            Assert.IsTrue(check);
        }

    }
}
