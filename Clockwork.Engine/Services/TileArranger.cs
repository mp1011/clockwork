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
            return pixelMap.Map(c => ChooseTile(c, pixelMap, tileset));
        }

        public Tile ChooseTile(PixelMapPoint mapPoint, ArrayGrid<PixelMapPoint> pixelMap, TileSet tileset)
        {
            var ret = new Tile(mapPoint.GridPosition, tileset.GetEmpty());

            var ruleSet = tileset.GetMatchingRuleset(mapPoint.Color);

            if (ruleSet != null)
            {
                foreach (var rule in ruleSet.GetMatchingRules(pixelMap, mapPoint))
                    ret = rule.Apply(ret, tileset);
            }
            
            return ret;
        }
    }
}
