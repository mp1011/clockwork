using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class TileMapLoader : ObjectLoader<TileMapConfig, TileMap>
    {
        public TileMapLoader(IResourceLoader resourceLoader) : base(resourceLoader) {}

        protected override TileMap Create(TileMapConfig config)
        {
            return new TileMap(config);
        }
    }
}
