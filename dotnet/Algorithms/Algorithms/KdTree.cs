using System;

namespace Algorithms {

    public class KdTree {

        private KdNode root;
        private int size;

        public KdTree() {
            root = null;
            size = 0;
        }

        public void Insert(Point2D point) {
            root = Insert(root, point.X, point.Y, vertical:true);
        }

        private KdNode Insert(KdNode node, double x, double y, bool vertical) {
            if (node == null) {
                return new KdNode(x, y, vertical);
            }
            throw new NotImplementedException();
        }

        private class KdNode {

            public double X { get; private set; }

            public double Y { get; private set; }

            public bool Vertical { get; private set; }

            public KdNode Left { get; set; }

            public KdNode Right { get; set; }

            public KdNode(double x, double y, bool vertical) {
                this.X = x;
                this.Y = Y;
                this.Vertical = vertical;
            }

        }

    }

    public class Point2D {

        public double X { get; private set; }

        public double Y { get; private set; }

        public Point2D(double x, double y) {
            this.X = x;
            this.Y = y;
        }
    }

    public class RectHV {

        public double Xmin { get; private set; }
        public double Ymin { get; private set; }
        public double Xmax { get; private set; }
        public double Ymax { get; private set; }

        public RectHV(double xmin, double ymin, double xmax, double ymax) {
            this.Xmin = xmin;
            this.Ymin = ymin;
            this.Xmax = xmax;
            this.Ymax = ymax;
        }
    }
}