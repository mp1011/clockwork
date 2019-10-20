using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services.Resource;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class SceneLoader : ObjectLoader<SceneConfig, Scene>
    {
        private TileMapLoader _tileMapLoader; 

        public SceneLoader(ResourceService resourceService, TileMapLoader tileMapLoader) 
            : base(resourceService)
        {
            _tileMapLoader = tileMapLoader;
        }

        protected override Scene Create(SceneConfig config)
        {
            var tileMap = _tileMapLoader.Load(config.TileMap);
            var layer = new DisplayLayer(tileMap.Position.Size, new IDisplayable[] { tileMap });
            return new Scene(new DisplayLayer[] { layer });
        }
    }
}
