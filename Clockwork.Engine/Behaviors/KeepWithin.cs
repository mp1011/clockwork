using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;
using System;

namespace Clockwork.Engine.Behaviors
{
    public class KeepWithin : IBehavior
    {
        public IWithPosition ObjectToMove { get; }
        public Rectangle Bounds { get; }

        public KeepWithin(IWithPosition objectToMove, Rectangle bounds)
        {
            ObjectToMove = objectToMove;
            Bounds = bounds;
        }

        public void Update(TimeSpan elapsed)
        {
            ObjectToMove.Position.KeepWithin(Bounds);
        }
    }
}
