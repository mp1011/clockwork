using Clockwork.Engine;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services.Factories;
using Clockwork.Engine.Services.Graphics;
using Clockwork.Engine.Services.ObjectLoaders;
using Clockwork.Tests.MockFactories;
using FluentAssertions;
using NUnit.Framework;

namespace Clockwork.Tests.Services.Graphics
{
    class RenderServiceTests : TestBase
    {
        [Test]
        public void CanRenderTileMap()
        {
            var mapName = "testmap";
            var mapLoader = DIRegistrar.GetInstance<TileMapLoader>();
            var map = mapLoader.Load(mapName);

            bool hit1 = false, hit2=false;

            var mockPainter = ITexturePainterMockFactory.Create(
                (textureName, region, destination) =>
                {
                    if (destination.UpperLeft.X == 0 && destination.UpperLeft.Y == 0)
                    {
                        hit1 = true;
                        region.Left.Should().Be(80);
                        region.Top.Should().Be(112);
                    }

                    if (destination.UpperLeft.X == 5*16 && destination.UpperLeft.Y == 16)
                    {
                        hit2 = true;
                        region.Left.Should().Be(112);
                        region.Top.Should().Be(112);
                    }
                });

            var svc = new RenderService(mockPainter);
            var camera = new Camera(new Size(320, 240));
            svc.RenderObject(camera, map);

            hit1.Should().BeTrue();
            hit2.Should().BeTrue();
        }

        [Test]
        public void OffscreenObjectsAreNotDrawn()
        {
            var texture = "forest_tiles";

            var mockPainter = ITexturePainterMockFactory.Create(
                (textureName, region, destination) =>
                {
                    Assert.Fail();
                });

            var svc = new RenderService(mockPainter);
            var drawable = DIRegistrar.GetInstance<SimpleGraphicFactory>().Create(texture);
            var camera = new Camera(new Size(320, 240));
            drawable.Position.SetLeft(-500);
            svc.RenderObject(camera, drawable);
        }

        [Test]
        public void CanRenderScene()
        {
            var scene = DIRegistrar.GetInstance<SceneLoader>().Load("testScene");
            bool hit = false;
            var mockPainter = ITexturePainterMockFactory.Create(
                (textureName, region, destination) =>
                {
                    if (destination.UpperLeft.X == 0 && destination.UpperLeft.Y == 0)
                    {
                        hit = true;
                        region.Left.Should().Be(80);
                        region.Top.Should().Be(112);
                    }
                });

            var svc = new RenderService(mockPainter);
            svc.RenderScene(new Camera(new Size(320, 240)), scene);
            hit.Should().BeTrue();
        }

        [Test]
        public void CanRenderSimpleGraphic()
        {
            var texture = "forest_tiles";

            var mockPainter = ITexturePainterMockFactory.Create(
                (textureName,region,destination)=>
                {
                    textureName.Should().Be(texture);
                    destination.Width.Should().Be(160);
                    destination.Height.Should().Be(128);
                    destination.Right.Should().Be(260);
                });

            var svc = new RenderService(mockPainter);
            var drawable = DIRegistrar.GetInstance<SimpleGraphicFactory>().Create(texture);
            var camera = new Camera(new Size(320, 240));
            drawable.Position.SetLeft(100);
            svc.RenderObject(camera, drawable);
        }
    }
}
