using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Models.TileSets;

namespace Clockwork.Engine.Models.Config
{
    public class TileConfig
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileFlags Flags { get; set; }
    }
}
