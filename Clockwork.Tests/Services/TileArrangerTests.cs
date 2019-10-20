using Clockwork.Engine;
using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Services;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.ObjectLoaders;
using Clockwork.Engine.Services.Resource;
using FluentAssertions;
using NUnit.Framework;

namespace Clockwork.Tests.Services
{
    class TileArrangerTests : TestBase
    {
        [TestCase("testmap",14,17,3,0)]
        public void TestTileArrangement(string mapName, int mapX, int mapY, int expectedTileX, int expectedTileY)
        {
            var resourceService = DIRegistrar.GetInstance<ResourceService>();
            var tileMapConfig = resourceService.LoadResource<TileMapConfig>(mapName);
            var mapLoader = DIRegistrar.GetInstance<TileMapLoader>();

            var tileSet = DIRegistrar.GetInstance<TileSetLoader>().Load(tileMapConfig.TilesetName);
            var pixelMap = mapLoader.GetPixelMap(tileMapConfig, tileSet);

            var arranger = DIRegistrar.GetInstance<TileArranger>();

            var tile = arranger.ChooseTile(pixelMap.GetFromPoint(mapX, mapY), pixelMap, tileSet);

            tile.Description
                .GridPosition
                .Should()
                .BeEquivalentTo(new Point(expectedTileX, expectedTileY));
        }

    }
}
