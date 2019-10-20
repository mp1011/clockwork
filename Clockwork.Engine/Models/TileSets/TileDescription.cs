using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.TileSets
{
    public class TileDescription : IWithGridPosition
    {
        public Point GridPosition { get; }
        public TileFlags Flags { get; }

        public TileDescription(Point position, TileFlags flags)
        {
            GridPosition = position;
            Flags = flags;
        }
    }
}
