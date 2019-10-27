using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.GameObjectInterfaces
{
    public interface IWithPosition : IGameObject
    {
        Rectangle Position { get; }
    }
}
