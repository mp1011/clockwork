using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.TileSets;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;
using System;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class TileSetLoader : ObjectLoader<TileSetConfig, TileSet>
    {
        public TileSetLoader(ResourceService resourceService) : base(resourceService) { }

        protected override TileSet Create(TileSetConfig config)
        {
            return new TileSet();
        }
    }
}
