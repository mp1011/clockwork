using Clockwork.Engine.Models.General;
using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Engine.Models.TileSets
{
    public class TileSet
    {
        private readonly ArrayGrid<TileDescription> _tiles;
        private readonly TilePlacementRuleSet[] _tilePlacementRules;

        public Size TileSize { get; }

        public TileSet(ArrayGrid<TileDescription> tiles, Size tileSize, TilePlacementRuleSet[] tilePlacementRules)
        {
            _tiles = tiles;
            _tilePlacementRules = tilePlacementRules;
            TileSize = tileSize;
        }

        public TileDescription GetEmpty()
        {
            return _tiles.GetFromPoint(0, 0);
        }

        public TileDescription GetFromPoint(Point p)
        {
            return _tiles.GetFromPoint(p);
        }

        public TilePlacementRuleSet GetMatchingRuleset(Color pixelMapColor)
        {
            return _tilePlacementRules.FirstOrDefault(p => p.Color != null && p.Color.Equals(pixelMapColor));
        }
    }
}
