using System;

namespace Clockwork.Engine.Models.GameObjectInterfaces
{
    public interface IUpdateable : IGameObject
    {
        void Update(TimeSpan elapsed);
    }
}
