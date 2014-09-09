using System;
using System.Linq;

namespace Beginor.X2048.Models {

    public class Traversals {

        public int[] X { get; private set; }
        public int[] Y { get; private set; }

        private Traversals() {
            X = new int[AppConsts.TileCount];
            Y = new int[AppConsts.TileCount];
            for (var pos = 0; pos < AppConsts.TileCount; pos++) {
                X[pos] = pos;
                Y[pos] = pos;
            }
        }

        public static Traversals FromVector(Vector v) {
            var traversals = new Traversals();
            if (v.X == 1) {
                traversals.X = traversals.X.Reverse().ToArray();
            }
            if (v.Y == 1) {
                traversals.Y = traversals.Y.Reverse().ToArray();
            }
            return traversals;
        }
    }
    
}
