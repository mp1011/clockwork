using Clockwork.Engine;
using Clockwork.Engine.Services.ObjectLoaders;
using NUnit.Framework;

namespace Clockwork.Tests.Services
{
    class MapLoaderTests : TestBase
    {
        [TestCase("testmap")]
        public void TestLoadMap(string mapName)
        {
            var mapLoader = DIRegistrar.GetInstance<TileMapLoader>();
            var map = mapLoader.Load(mapName);
         
            Assert.Fail();
        }
    }
}
