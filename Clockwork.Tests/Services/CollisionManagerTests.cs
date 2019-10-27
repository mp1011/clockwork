using Clockwork.Engine;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services;
using FluentAssertions;
using NUnit.Framework;
using System.Numerics;

namespace Clockwork.Tests.Services
{
    class CollisionManagerTests : TestBase
    {
        [TestCase(0,0,0,0)]
        [TestCase(-50, 0, 0, 0)]
        [TestCase(-50, -50, 0, 0)]
        [TestCase(190, -50, 150, 0)]
        [TestCase(190,190, 150, 150)]
        public void CameraRemainsInBounds(int x, int y, int newX, int newY)
        {
            Scene scene = new Scene(new DisplayLayer(new Size(200, 200)));

            Camera camera = new Camera(new Size(50, 50), new Rectangle(scene.Bounds));
            camera.Position.UpperLeft = new Vector2(x, y);


            var collisionManager = new CollisionManager();
            collisionManager.Add(camera);
            collisionManager.HandleCollisions();

            camera.Position.Left.Should().Be(newX);
            camera.Position.Top.Should().Be(newY);
        }
    }
}
