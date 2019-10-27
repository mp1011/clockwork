using System;
using Clockwork.Engine.Extensions;
using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Behaviors
{
    public class PositionRelativeTo : IBehavior
    {
        public IWithPosition ObjectToMove { get; }
        public IWithPosition ObjectToFollow { get; }
        public Point Offset { get; } = Point.Zero;

        public PositionRelativeTo(IWithPosition objectToMove, IWithPosition objectToFollow, Point offset)
        {
            ObjectToMove = objectToMove;
            ObjectToFollow = objectToFollow;
            Offset = offset;
        }

        public void Update(TimeSpan elapsedInFrame)
        {
            ObjectToMove.Position.Center = ObjectToFollow
                .Position
                .Center
                .Translate(Offset);
        }
    }
}
