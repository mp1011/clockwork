using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;
using NSubstitute;
using System;

namespace Clockwork.Tests.MockFactories
{
    public class IMoveableFactory
    {
        public static IMoveable Create()
        {
            var mock = Substitute.For<IMoveable>();

            var position = new Rectangle();
            mock.Position.Returns(x => position);

            var motion = new MotionVector();
            mock.MotionVector.Returns(x => motion);

            return mock;
        }
    }
}
