using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Engine.Models.TileSets
{
    public class TilePlacementRuleSet
    {
        public Color Color { get; }
        public string[] Tags { get; }

        public TilePlacementRule[] Rules { get; }

        public TilePlacementRuleSet(TileRuleSetConfig config)
        {
            Color = config.MapColor;

            var tags = (config.ExtraTags ?? new string[]{}).ToList();
            tags.Add(config.Name);
            Tags = tags.ToArray();
            Rules = config.TileRules.Select(c => new TilePlacementRule(c)).ToArray();
        }

        public bool CanApplyToPoint(Color pixelColor)
        {
            if (Color != null)
                return pixelColor == Color;
            else
                return true;
        }

        public TilePlacementRule[] GetMatchingRules(ArrayGrid<PixelMapPoint> map, PixelMapPoint mapPoint)
        {
            return Rules.Where(p => p.CanApplyToPoint(map, mapPoint)).ToArray();
        }
    }
}
