using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.TileSets;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;
using System;
using System.Linq;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class TileSetLoader : ObjectLoader<TileSetConfig, TileSet>
    {
      
        public TileSetLoader(ResourceService resourceService) 
            : base(resourceService)
        {
        }

        protected override TileSet Create(TileSetConfig config)
        {
            var tiles = new ArrayGrid<TileDescription>(
                width: config.TextureSize.Width / config.TileSize.Width,
                height: config.TextureSize.Height / config.TileSize.Height);

            foreach(var tile in config.Tiles)
            {
                var pt = new Point(tile.X, tile.Y);
                tiles.Set(pt, new TileDescription(pt, tile.Flags));
            }

            return new TileSet(tiles, config.RuleSets.Select(r=> new TilePlacementRuleSet(r)).ToArray());
        }
    }
}
