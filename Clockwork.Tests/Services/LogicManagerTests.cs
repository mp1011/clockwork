using Clockwork.Engine;
using Clockwork.Engine.Behaviors;
using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services;
using Clockwork.Tests.MockFactories;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Numerics;

namespace Clockwork.Tests.Services
{
    class LogicManagerTests :TestBase
    {
        [TestCase(0, 0, 0, 0)]
        [TestCase(-50, 0, 0, 0)]
        [TestCase(-50, -50, 0, 0)]
        [TestCase(190, -50, 150, 0)]
        [TestCase(190, 190, 150, 150)]
        public void CameraRemainsInBounds(int x, int y, int newX, int newY)
        {
            Scene scene = new Scene(new DisplayLayer(new Size(200, 200)));
            Camera camera = new Camera(new Size(50, 50), new Rectangle(scene.Bounds));
            camera.Position.UpperLeft = new Vector2(x, y);

            RunFrames(TimeSpan.FromMilliseconds(100), TimeSpan.FromMinutes(5), new KeepWithin(camera, new Rectangle(Point.Zero, scene.Bounds)));

            camera.Position.Left.Should().Be(newX);
            camera.Position.Top.Should().Be(newY);
        }

        [Test]
        public void CameraCanFollowObjectAndStopAtRightSide()
        {
            var scene = new Scene(new DisplayLayer(new Size(1000, 100)));
            var camera = new Camera(new Size(100,100), scene.Bounds);
            var movingObject = IMoveableFactory.Create(0, 100);

            RunFrames(TimeSpan.FromMilliseconds(100), 
                        TimeSpan.FromMinutes(5), 
                        camera,
                        movingObject,
                        new PositionRelativeTo(camera, movingObject, Point.Zero),
                        new KeepWithin(camera, new Rectangle(Point.Zero, scene.Bounds)));

            camera.Position.Right.Should().Be(1000);
        }

        public static void RunFrames(TimeSpan timePerFrame, TimeSpan totalDuration, params IGameObject[] gameObjects)
        {
            var logicManager = DIRegistrar.GetInstance<LogicManager>();
            foreach(var gameObject in gameObjects)
                logicManager.Add(gameObject);

            var totalElapsed = TimeSpan.Zero;
            while (totalElapsed < totalDuration)
            {
                logicManager.Update(timePerFrame);
                totalElapsed += timePerFrame;
            }
        }
    }
}
