using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CubeSolvingAssignment.Graphs;

namespace CubeSolvingAssignment
{
    public partial class MiniCubeSolver : Form
    {
        private readonly Dictionary<string, double> _xPositions = new Dictionary<string, double>();
        private readonly Dictionary<string, double> _yPositions = new Dictionary<string, double>();
        private readonly double _widthProportion;
        private readonly double _heightProportion;

        private Cube Cube { get; set; }
        private List<Edge> Solution { get; set; }
        private Stopwatch FormStopwatch { get; }
        private float SolutionTime { get; set; }
        private float ShortestRouteTime { get; set; }

        public MiniCubeSolver()
        {
            SolutionTime = 0;
            ShortestRouteTime = 0;

            FormStopwatch = new Stopwatch();
            InitializeComponent();
            Cube = new Cube(6, 4);

            _widthProportion = Convert.ToDouble(sqr8.Width) / Convert.ToDouble(grpBoxCube.Width);
            _heightProportion = Convert.ToDouble(sqr8.Height) / Convert.ToDouble(grpBoxCube.Height);

            foreach (Control c in grpBoxCube.Controls)
            {
                var xProportion = Convert.ToDouble(c.Location.X) / Convert.ToDouble(grpBoxCube.Width);
                var yProportion = Convert.ToDouble(c.Location.Y) / Convert.ToDouble(grpBoxCube.Height);
                _xPositions.Add(c.Name, xProportion);
                _yPositions.Add(c.Name, yProportion);
            }
        }

        private void ResetSolver()
        {
            SolutionTime = 0;
            ShortestRouteTime = 0;
            Cube = new Cube(6, 4);
            DrawCube();
            listBoxSolution.Items.Clear();
            btnRotateSolve.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateDropDowns();
            DrawCube();
            btnSolve.Enabled = false;
            btnRotateSolve.Enabled = false;
        }

        public void ChildClick(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;
            var parent = (ToolStripMenuItem) menuItem.OwnerItem;

            foreach (var itm in parent.DropDownItems)
            {
                ((ToolStripMenuItem)itm).Checked = false;
            }

            menuItem.Checked = true;
        }

        private void PopulateDropDowns()
        {
            cmbSide.DataSource = Enum.GetValues(typeof(Face));
            cmbDirection.DataSource = Enum.GetValues(typeof(Turn));

            var solvingMethodItem = new ToolStripMenuItem()
            {
                Name = "solvingMethodMenuItem",
                Text = @"Solving"
            };
            var solvingMethods = Enum.GetValues(typeof(SolvingMethod));

            var i = 0;
            foreach (var method in solvingMethods)
            {
                solvingMethodItem.DropDownItems.Add(method.ToString());
                ((ToolStripMenuItem) solvingMethodItem.DropDownItems[i]).Click += ChildClick;
                i++;
            }
            
            var shortestRouteItem = new ToolStripMenuItem()
            {
                Name = "shorestRouteAlgorithmMenuItem",
                Text = @"Shortest Route"
            };

            var shortestRoutes = Enum.GetValues(typeof(ShortestRoute));

            i = 0;
            foreach (var method in shortestRoutes)
            {
                shortestRouteItem.DropDownItems.Add(method.ToString());
                ((ToolStripMenuItem)shortestRouteItem.DropDownItems[i]).Click += ChildClick;
                i++;
            }
            
            ((ToolStripMenuItem)solvingMethodItem.DropDownItems[0]).Checked = true;
            ((ToolStripMenuItem)shortestRouteItem.DropDownItems[0]).Checked = true;
            menuStrip.Items.Add(solvingMethodItem);
            menuStrip.Items.Add(shortestRouteItem);
        }
        
        private void MiniCubeSolver_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in grpBoxCube.Controls)
            {
                var newWidth = _widthProportion * Convert.ToDouble(grpBoxCube.Width);
                c.Width = Convert.ToInt32(newWidth);

                var newHeight = _heightProportion * Convert.ToDouble(grpBoxCube.Height);
                c.Height = Convert.ToInt32(newHeight);
            }

            foreach (Control c in grpBoxCube.Controls)
            {
                var xPropotion = _xPositions[c.Name] * Convert.ToDouble(grpBoxCube.Width);
                var yPropotion = _yPositions[c.Name] * Convert.ToDouble(grpBoxCube.Height);
                c.Location = new Point(Convert.ToInt32(xPropotion), Convert.ToInt32(yPropotion));
            }

        }

        private void DrawCube()
        {
            for (int i = 0; i < Cube.TilesLength; i++)
            {
                var p = (Panel)Controls.Find("sqr" + i, true)[0];
                p.BackColor = Cube.Grid[i];
            }

        }

        private void RandomRotate()
        {
            var times = new Random().Next(1, 8);

            var valFaces = Enum.GetValues(typeof(Face));
            var valTurn = Enum.GetValues(typeof(Turn));

            for (int i = 0; i < times; i++)
            {
                var random = new Random();
                var randomFace = (Face)valFaces.GetValue(random.Next(valFaces.Length));
                var randomTurn = (Turn)valTurn.GetValue(random.Next(valTurn.Length));

                Cube = Cube.RotateCube(randomFace, randomTurn);
            }
            DrawCube();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            Face face;
            Enum.TryParse(cmbSide.SelectedValue.ToString(), out face);

            Turn turn;
            Enum.TryParse(cmbDirection.SelectedValue.ToString(), out turn);

            Cube = Cube.RotateCube(face, turn);
            DrawCube();
            btnSolve.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RandomRotate();
        }

        private GraphSettings GetGraphSettings()
        {
            var solvingMethod = (ToolStripMenuItem)menuStrip.Items[0];
            var methods = solvingMethod.DropDownItems;
            var selectedMethod = "";

            foreach (var check in methods.Cast<ToolStripMenuItem>().Where(check => check.Checked))
            {
                selectedMethod = check.Text;
            }
            var solving = (SolvingMethod)Enum.Parse(typeof(SolvingMethod), selectedMethod);

            var shortestMethod = (ToolStripMenuItem)menuStrip.Items[1];
            var algorithms = shortestMethod.DropDownItems;
            var selectedRoute = "";

            foreach (var check in algorithms.Cast<ToolStripMenuItem>().Where(check => check.Checked))
            {
                selectedRoute = check.Text;
            }
            var shortestRoute = (ShortestRoute)Enum.Parse(typeof(ShortestRoute), selectedRoute);

            var settings = new GraphSettings
            {
                SolvingMethodSetting = solving,
                ShortestRouteSetting = shortestRoute
            };

            return settings;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cube.IsSolved())
                {
                    return;
                }

                var settings = GetGraphSettings();

                /* Workaround to meet in the middle as it does not work well with bellmanford 
                   because it will take a long time if the solution have more than 3-4 steps
                */
                if (settings.SolvingMethodSetting == SolvingMethod.MeetInMiddle)
                {
                    settings.ShortestRouteSetting = ShortestRoute.Dijkstra;
                }

                var node = new Node
                {
                    CubeNode = Cube,
                    IsVisted = false
                };

                var graph = new Graph(node, settings);
                FormStopwatch.Start();
                graph.CreateGraph();
                FormStopwatch.Stop();

                SolutionTime = FormStopwatch.ElapsedMilliseconds;

                FormStopwatch.Restart();

                FormStopwatch.Start();
                Solution = graph.GetSolution();
                FormStopwatch.Stop();
                ShortestRouteTime = FormStopwatch.ElapsedMilliseconds;

                FormStopwatch.Restart();

                MessageBox.Show(
                    $"Solving Method Time Taken ({settings.SolvingMethodSetting}) :  {SolutionTime} ms, Shortest Route Time Taken ({settings.ShortestRouteSetting}) :  {ShortestRouteTime} ms");

                DisplayListBox();
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Something went wrong ! " + exception.Message);
            }
        }


        private void DisplayListBox()
        {
            listBoxSolution.Items.Clear();
            foreach (var edge in Solution)
            {
                listBoxSolution.Items.Add(edge);
            }
            if (listBoxSolution.Items.Count <= 0)
            {
                return;
            }

            btnRotateSolve.Enabled = true;
            listBoxSolution.SetSelected(0, true);
        }

        private void btnRotateSolve_Click(object sender, EventArgs e)
        {
            var edge = (Edge)listBoxSolution.Items[0];
            var edgeFace = edge.Face;
            var edgeTurn = edge.Turn;
            Solution.Remove(edge);
            DisplayListBox();

            Cube = Cube.RotateCube(edgeFace, edgeTurn);
            DrawCube();
            if (listBoxSolution.Items.Count > 0)
            {
                return;
            }

            btnRotateSolve.Enabled = false;
            btnSolve.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetSolver();
        }
    }
}
