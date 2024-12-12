using System.Drawing;

namespace Day_12
{
    internal class Region
    {
        public Region()
        {
            Coordinates = [];
        }

        public char Type { get; set; }
        public List<Point> Coordinates { get; set; }
    }
}
