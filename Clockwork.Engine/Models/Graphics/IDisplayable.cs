using Clockwork.Engine.Models.GameObjectInterfaces;

namespace Clockwork.Engine.Models.Graphics
{
    public interface IDisplayable : IWithPosition
    {
        ITextureSection[] Textures { get; }
    }
}
