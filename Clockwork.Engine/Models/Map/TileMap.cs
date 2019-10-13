using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Map
{
    public class TileMap
    {
        public ArrayGrid<Tile> Grid { get; }

        public TileMap(TileMapConfig config, ArrayGrid<Tile> grid)
        {
            Grid = grid;
        }
    }
}
