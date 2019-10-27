using Clockwork.Engine;
using Clockwork.Engine.Services;
using Clockwork.Tests.MockFactories;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Clockwork.Tests.Services
{
    class MotionManagerTests : TestBase
    {
        [TestCase(0,0,0,0)]
        [TestCase(90, 1, 0, -60)]
        [TestCase(180, 2, -120, 0)]
        [TestCase(45, 10, 424, -424)]
        public void ObjectCanMoveInAnyDirection(int angleInDegrees, int distancePerSecond, int newXAfterOneMinute, int newYAfterOneMinute)
        {
            var manager = DIRegistrar.GetInstance<MotionManager>();
            var movingObject = IMoveableFactory.Create(angleInDegrees, distancePerSecond);

        
            manager.AddObject(movingObject);
            manager.ApplyMotion(TimeSpan.FromMinutes(1));

            movingObject.Position.Center.X.Should().BeApproximately(newXAfterOneMinute,1f);
            movingObject.Position.Center.Y.Should().BeApproximately(newYAfterOneMinute,1f);
        }
    }
}
