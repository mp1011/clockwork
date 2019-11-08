using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;
using NSubstitute;
using System;

namespace Clockwork.Tests.MockFactories
{
    public class ICollidableFactory
    {
        public static ICollidable Create(int angleInDegrees, int motionPerSecond)
        {
            var mock = Substitute.For<ICollidable>();

            var position = new Rectangle();
            mock.Position.Returns(x => position);

            var motion = new MotionVector();
            motion.MagnitudePerSecond = motionPerSecond;
            motion.Angle.SetDegrees(angleInDegrees);

            mock.MotionVector.Returns(x => motion);

            return mock;
        }
    }
}
