using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.GameObjectInterfaces
{
    public interface ICollidable : IMoveable
    {
        Rectangle Bounds { get; }
    }
}
