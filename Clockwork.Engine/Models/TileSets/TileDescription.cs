using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.TileSets
{
    public class TileDescription : IWithGridPosition
    {
        public Point Position { get; }
        public TileFlags Flags { get; }

        public TileDescription(Point position, TileFlags flags)
        {
            Position = position;
            Flags = flags;
        }
    }
}
