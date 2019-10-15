using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.TileSets;

namespace Clockwork.Engine.Models.Config
{
    public class TileRuleConfig
    {
        public Point Cell { get; set; }

        public string Self { get; set; }
        public string Right { get; set; }
        public string Bottom { get; set; }
        public string Left { get; set; }
        public string Top { get; set; }
        public string TopLeftCorner { get; set; }
        public string BottomLeftCorner { get; set; }
        public string TopRightCorner { get; set; }
        public string BottomRightCorner { get; set; }

        public TileLayer Layer { get; set; }

        public int Chance { get; set; }

        public TileRuleConfig() { }

        public TileRuleConfig(int x, int y, string self=null, string right = null, string bottom = null, string left = null, string top = null,
            string topLeft=null, string bottomLeft = null, string topRight = null, string bottomRight = null,
            TileLayer layer = TileLayer.Cell, int chance=0)
        {
            Cell = new Point(x,y);
            Right = right;
            Bottom = bottom;
            Left = left;
            Top = top;
            TopLeftCorner = topLeft;
            TopRightCorner = topRight;
            BottomLeftCorner = bottomLeft;
            BottomRightCorner = bottomRight;
        }
    }
}
