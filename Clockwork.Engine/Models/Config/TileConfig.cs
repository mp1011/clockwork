using Clockwork.Engine.Models.Map;

namespace Clockwork.Engine.Models.Config
{
    public class TileConfig
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileFlags Flags { get; set; }
    }
}
