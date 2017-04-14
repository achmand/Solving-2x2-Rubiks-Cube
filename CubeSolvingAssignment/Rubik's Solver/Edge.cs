namespace CubeSolvingAssignment
{
    public sealed class Edge
    {
        public Node NewCube { get; set; }
        public Node PrevCube { get; set; }
        public Face Face { get; set; }
        public Turn Turn { get; set; }
        public int Weight { get; set; }

        public Edge( Node prevCube, Node newCube, Face face, Turn turn, int weight)
        {
            NewCube = newCube;
            PrevCube = prevCube;
            Face = face;
            Turn = turn;
            Weight = weight;
        }

        public override string ToString()
        {
            return Face + " " + Turn;
        }
    }
}
