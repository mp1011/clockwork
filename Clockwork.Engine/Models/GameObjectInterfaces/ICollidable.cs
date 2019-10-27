using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.GameObjectInterfaces
{
    public interface ICollidable : IWithPosition
    {
        Rectangle Bounds { get; }
    }
}
