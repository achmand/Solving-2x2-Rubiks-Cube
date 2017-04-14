using System;
using System.Collections.Generic;
using System.Drawing;

namespace CubeSolvingAssignment
{
    public enum Face
    {
        Left = 0,
        Top = 1,
        Front = 2,
        Bottom = 3,
        Right = 4,
        Back = 5
    }

    public enum Turn
    {
        Clockwise = 0,
        AntiClockwise = 1
    }

    public sealed class Cube
    {
        public Color[] Grid { get; set; }
        public int TotalFaces { get; set; }
        public int SqauresPerFace { get; set; }
        public int TilesLength => TotalFaces * SqauresPerFace;

        private readonly Dictionary<Face, int[]> _extendedFaces;

        private readonly int[] _extendedFront = { 8, 9, 10, 11, 6, 7, 16, 18, 13, 12, 3, 1 };
        private readonly int[] _extendedRight = { 16, 17, 18, 19, 7, 5, 20, 22, 15, 13, 11, 9 };
        private readonly int[] _extendedBack = { 20, 21, 22, 23, 5, 4, 0, 2, 14, 15, 19, 17 };
        private readonly int[] _extendedBottom = { 12, 13, 14, 15, 10, 11, 18, 19, 22, 23, 2, 3 };
        private readonly int[] _extendedTop = { 4, 5, 6, 7, 21, 20, 17, 16, 9, 8, 1, 0 };
        private readonly int[] _extendedLeft = { 0, 1, 2, 3, 4, 6, 8, 10, 12, 14, 23, 21 };

        private readonly Color[] _colors = { Color.Green, Color.White, Color.Red, Color.Yellow, Color.Blue, Color.Orange };

        public Cube(int totalFaces, int squaresPerFace)
        {
            TotalFaces = totalFaces;
            SqauresPerFace = squaresPerFace;

            Grid = new Color[TotalFaces * squaresPerFace];

            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = _colors[i / 4];
            }

            _extendedFaces = new Dictionary<Face, int[]>
            {
                {Face.Front, _extendedFront},
                {Face.Back, _extendedBack},
                {Face.Left, _extendedLeft},
                {Face.Right, _extendedRight},
                {Face.Top, _extendedTop},
                {Face.Bottom, _extendedBottom}
            };
        }

        public Cube(int totalFaces, int squaresPerFace, Color[] otherColors)
        {
            TotalFaces = totalFaces;
            SqauresPerFace = squaresPerFace;

            Grid = new Color[TotalFaces * squaresPerFace];

            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = otherColors[i / 4];
            }

            _extendedFaces = new Dictionary<Face, int[]>
            {
                {Face.Front, _extendedFront},
                {Face.Back, _extendedBack},
                {Face.Left, _extendedLeft},
                {Face.Right, _extendedRight},
                {Face.Top, _extendedTop},
                {Face.Bottom, _extendedBottom}
            };
        }

        public Cube(Color[] grid, Dictionary<Face, int[]> extendedFaces)
        {
            Grid = (Color[])grid.Clone();
            _extendedFaces = extendedFaces;

        }

        // Rotates the cube by returning a new jumbled cube according to the rotation provided
        public Cube RotateCube(Face face, Turn turn)
        {
            switch (turn) // Switches according to the turn 
            {
                case Turn.Clockwise:
                    return RotateCw(_extendedFaces[face]); // returns the required extended faces from the dictionary
                case Turn.AntiClockwise:
                    return RotateAcw(_extendedFaces[face]);
                default:
                    throw new ArgumentOutOfRangeException(nameof(turn), turn, null);
            }
        }

        // Used to rotate any face clockwise and returns a cube
        private Cube RotateCw(int[] extFaces)
        {
            var result = new Cube(Grid, _extendedFaces)
            {
                Grid =
                {
                    [extFaces[0]] = Grid[extFaces[2]],
                    [extFaces[1]] = Grid[extFaces[0]],
                    [extFaces[3]] = Grid[extFaces[1]],
                    [extFaces[2]] = Grid[extFaces[3]],
                    [extFaces[4]] = Grid[extFaces[10]],
                    [extFaces[5]] = Grid[extFaces[11]],
                    [extFaces[6]] = Grid[extFaces[4]],
                    [extFaces[7]] = Grid[extFaces[5]],
                    [extFaces[8]] = Grid[extFaces[6]],
                    [extFaces[9]] = Grid[extFaces[7]],
                    [extFaces[11]] = Grid[extFaces[9]],
                    [extFaces[10]] = Grid[extFaces[8]]
                },
                TotalFaces = TotalFaces,
                SqauresPerFace = SqauresPerFace
            };
            return result;
        }

        // Used to rotate any face anticlockwise and returns a cube
        private Cube RotateAcw(int[] extFaces)
        {
            var result = new Cube(Grid, _extendedFaces)
            {
                Grid =
                {
                    [extFaces[2]] = Grid[extFaces[0]],
                    [extFaces[0]] = Grid[extFaces[1]],
                    [extFaces[1]] = Grid[extFaces[3]],
                    [extFaces[3]] = Grid[extFaces[2]],
                    [extFaces[10]] = Grid[extFaces[4]],
                    [extFaces[11]] = Grid[extFaces[5]],
                    [extFaces[4]] = Grid[extFaces[6]],
                    [extFaces[5]] = Grid[extFaces[7]],
                    [extFaces[6]] = Grid[extFaces[8]],
                    [extFaces[7]] = Grid[extFaces[9]],
                    [extFaces[9]] = Grid[extFaces[11]],
                    [extFaces[8]] = Grid[extFaces[10]]
                },
                TotalFaces = TotalFaces,
                SqauresPerFace = SqauresPerFace
            };

            return result;
        }

        // Checks if this cube is solved and returns a boolean
        public bool IsSolved()
        {
            var tmpColor = Color.Black; // Sets a tmp color to black 
            for (int i = 0; i < Grid.Length; i++)
            {
                if (i % SqauresPerFace == 0) // Checking if the remainder of i/4 is 0
                {
                    tmpColor = Grid[i]; // Color is changed by
                }
                if (Grid[i] != tmpColor) // If not the same color return false
                {
                    return false;
                }
            }
            return true; // All colors sets of 4s match return true
        }
    }
}
