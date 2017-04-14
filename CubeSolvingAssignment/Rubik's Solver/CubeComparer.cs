using System.Collections.Generic;
using System.Linq;

namespace CubeSolvingAssignment
{
    public sealed class CubeComparer : IEqualityComparer<Cube>
    {
        public bool Equals(Cube x, Cube y)
        {
            return x.Grid.SequenceEqual(y.Grid);
        }

        public int GetHashCode(Cube obj)
        {
            var hc = obj.Grid.Length;
            for (int i = 0; i < obj.Grid.Length; ++i)
            {
                hc = unchecked(hc * 314159 + obj.Grid[i].ToArgb());
            }
            return hc;
        }
    }
}
