using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using FluentAssertions;
using NUnit.Framework;
using System.Numerics;

namespace Clockwork.Tests.Models.Graphics
{
    class CameraTests : TestBase
    {
        [TestCase(0,0,100,100)]
        [TestCase(25, 0, 75, 100)]
        [TestCase(0, -25, 100, 125)]
        public void GetScreenPositionFromWorldPosition(int cameraX, int cameraY, int screenX, int screenY)
        {
            var camera = new Camera(new Size(320, 240), new Rectangle(0, 0, 1000, 1000));
            camera.Position.UpperLeft = new Vector2(cameraX, cameraY);

            var worldPos = new Rectangle(100, 100, 25, 25);

            var screenPos = camera.GetScreenPosition(worldPos);

            screenPos.UpperLeft
                .Should()
                .BeEquivalentTo(new Vector2(screenX, screenY));

        }
    }
}
