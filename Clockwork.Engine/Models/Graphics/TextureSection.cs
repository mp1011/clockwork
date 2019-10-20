using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Graphics
{
    public class TextureSection
    {
        public string TextureKey { get; }
        public Rectangle TextureRegion { get; }
        public Point Offset { get; }

        public TextureSection(string textureKey, Rectangle textureRegion, Point offset)
        {
            TextureKey = textureKey;
            TextureRegion = textureRegion;
            Offset = offset;
        }
    }
}
