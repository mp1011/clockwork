using Clockwork.Engine.Models.GameObjectInterfaces;
using System;

namespace Clockwork.Engine.Behaviors
{
    public interface IBehavior : IGameObject
    {
        void Update(TimeSpan elapsedInFrame);
    }
}
