using Clockwork.Engine;
using Clockwork.Engine.Services.ObjectLoaders;
using FluentAssertions;
using NUnit.Framework;

namespace Clockwork.Tests.Services
{
    class MapLoaderTests : TestBase
    {
        [TestCase("testmap",32,32)]
        public void TestLoadMap(string mapName, int expectedTilesX, int expectedTilesY)
        {
            var mapLoader = DIRegistrar.GetInstance<TileMapLoader>();
            var map = mapLoader.Load(mapName);

            map.Grid.GridSize.Width
                .Should()
                .Be(expectedTilesX);

            map.Grid.GridSize.Height
             .Should()
             .Be(expectedTilesY);
        }
    }
}
