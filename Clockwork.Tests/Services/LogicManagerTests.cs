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

namespace Clockwork.Tests.Services
{
    class LogicManagerTests :TestBase
    {
        [Test]
        public void CameraCanFollowObjectAndStopAtRightSide()
        {
            var logicManager = DIRegistrar.GetInstance<LogicManager>();
            var scene = new Scene(new DisplayLayer(new Size(1000, 100)));
            var camera = new Camera(new Size(100,100), scene.Bounds);

            var movingObject = IMoveableFactory.Create(0, 100);

            logicManager.Add(camera);
            logicManager.Add(movingObject);
            logicManager.Add(new PositionRelativeTo(camera, movingObject, Point.Zero));
            
            RunFrames(logicManager, TimeSpan.FromMilliseconds(100), TimeSpan.FromMinutes(5));

            camera.Position.Right.Should().Be(1000);
        }

        private void RunFrames(LogicManager manager, TimeSpan timePerFrame, TimeSpan totalDuration)
        {
            var totalElapsed = TimeSpan.Zero;
            while(totalElapsed < totalDuration)
            {
                manager.Update(timePerFrame);
                totalElapsed += timePerFrame;
            }
        }
    }
}
