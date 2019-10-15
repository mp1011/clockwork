using Clockwork.Engine;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Services.ObjectLoaders;
using FluentAssertions;
using NUnit.Framework;

namespace Clockwork.Tests.Services
{
    class TileArrangerTests : TestBase
    {
        [TestCase("testmap",14,17,3,0)]
        public void TestTileArrangement(string mapName, int mapX, int mapY, int expectedTileX, int expectedTileY)
        { 
            var mapLoader = DIRegistrar.GetInstance<TileMapLoader>();
            var map = mapLoader.Load(mapName);

            var tile = map.Grid.GetFromPoint(mapX, mapY);

            tile.Description
                .Position
                .Should()
                .BeEquivalentTo(new Point(expectedTileX, expectedTileY));
        }

    }
}
