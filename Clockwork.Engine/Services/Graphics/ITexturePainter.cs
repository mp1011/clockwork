using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Services.Graphics
{
    public interface ITexturePainter
    {
        void DrawTextureRegion(string textureKey, Rectangle textureRegion, Rectangle destination);
    }
}
