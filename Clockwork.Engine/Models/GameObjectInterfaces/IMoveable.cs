using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.GameObjectInterfaces
{
    public interface IMoveable : IWithPosition
    {
        MotionVector MotionVector { get; }
    }
}
