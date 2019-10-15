using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.TileSets;

namespace Clockwork.Engine.Models.Map
{
    public class Tile : IWithGridPosition
    {
        public Point Position { get; }

        public TileDescription Description { get; }

        public Tile(Point position, TileDescription description)
        {
            Position = position;
            Description = description;
        }
    }
}
