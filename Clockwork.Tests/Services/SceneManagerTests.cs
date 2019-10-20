using Clockwork.Engine;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Services;
using FluentAssertions;
using NUnit.Framework;

namespace Clockwork.Tests.Services
{
    class SceneManagerTests : TestBase
    {
        [Test]
        public void CanLoadInitialScene()
        {
            var manager = DIRegistrar.GetInstance<SceneManager>();
            var scene = manager.LoadInitialScene();
            scene.Layers[0].DisplayItems[0]
                .Should()
                .BeOfType<TileMap>();
        }
    }
}
