using System.Drawing;

namespace Day_10
{
    internal class PointWithDirection
    {
        public PointWithDirection() { }
        public PointWithDirection(Point point, Direction direction)
        {
            Point = point;
            Direction = direction;
        }

        public Point Point { get; set; }
        public Direction Direction { get; set; }

        public override string ToString()
        {
            return "(" + Point.X + ", " + Point.Y + ")" + " " + Direction.ToString();
        }
    }
}
