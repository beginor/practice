using System;

namespace Beginor.X2048.Models {

    public class Vector {

        public int X { get; private set; }
        public int Y { get; private set; }

        private static readonly Vector[] vectors = new [] {
            new Vector(0, -1), // Up
            new Vector(1, 0),  // Right
            new Vector(0, 1),  // Down
            new Vector(-1, 0)  // Left
        };

        public Vector(int x, int y) {
            X = x;
            Y = y;
        }

        public static Vector FromInt(int idx) {
            if (idx < 0 || idx > 3) {
                throw new ArgumentOutOfRangeException();
            }
            return vectors[idx];
        }

    }
    
}
