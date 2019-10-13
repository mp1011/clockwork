using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Models.TileSets;

namespace Clockwork.Engine.Services
{
    public class TileArranger
    {
        public ArrayGrid<Tile> ArrangeTiles(TileMapConfig map, ArrayGrid<PixelMapPoint> pixelMap, TileSet tileset)
        {
            return pixelMap.Map(c => new Tile());
        }
    }
}
