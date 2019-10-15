using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Models.TileSets;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class TileMapLoader : ObjectLoader<TileMapConfig, TileMap>
    {
        private readonly TileArranger _tileArranger;
        private readonly TileSetLoader _tileSetLoader;
        private readonly ITextureLoader _textureLoader;


        public TileMapLoader(ResourceService resourceService, TileArranger tileArranger, 
            TileSetLoader tileSetLoader, ITextureLoader textureLoader) 
            : base(resourceService)
        {
            _tileArranger = tileArranger;
            _tileSetLoader = tileSetLoader;
            _textureLoader = textureLoader;
        }

        private ArrayGrid<PixelMapPoint> GetPixelMap(TileMapConfig map, TileSet tileSet)
        {
            var colors = _textureLoader.LoadPixels(map.Name);
            return colors.Map(color =>
            {
                var tileRule = tileSet.GetMatchingRuleset(color.Item);
                return new PixelMapPoint(color.Item, color.Position, tileRule?.Tags ?? new string[] { "background","empty" });
            });
        }

        protected override TileMap Create(TileMapConfig config)
        {
            var tileSet = _tileSetLoader.Load(config.TilesetName);
            var pixelMap = GetPixelMap(config, tileSet);
            var tiles = _tileArranger.ArrangeTiles(config, pixelMap, tileSet);
            return new TileMap(config, tiles);
        }
    }
}
