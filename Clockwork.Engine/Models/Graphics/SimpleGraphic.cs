using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Graphics
{
    public class SimpleGraphic : IDisplayable
    {
        private string _textureKey;
        public Rectangle Position { get; } 

        public ITextureSection[] Textures { get; }

        public SimpleGraphic(string textureKey, Rectangle textureRegion)
        {
            _textureKey = textureKey;
            Textures = new ITextureSection[] { new TextureSection(_textureKey, textureRegion, new Point(0, 0)) };
            Position = new Rectangle(0, 0, textureRegion.Width, textureRegion.Height);
        }
    }
}
