using Clockwork.Engine.Models.General;
using Clockwork.Engine.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Clockwork.Engine.Models.General.Rectangle;
namespace Clockwork.MonoGame.Implementations
{
    public class XNATexturePainter : ITexturePainter
    {
        private ITextureLoader<Texture2D> _textureLoader;
        private XNAGraphicsInfoProvider _graphicsInfoProvider;

        public XNATexturePainter(ITextureLoader<Texture2D> textureLoader, 
            XNAGraphicsInfoProvider graphicsInfoProvider)
        {
            _textureLoader = textureLoader;
            _graphicsInfoProvider = graphicsInfoProvider;
        }

        public void DrawTextureRegion(string textureKey, Rectangle textureRegion, Rectangle destination)
        {
            var texture = _textureLoader.LoadTexture(textureKey);
            var spriteBatch = _graphicsInfoProvider.SpriteBatch;

            var destRec = destination.ToXNARec();
            var srcRec = textureRegion.ToXNARec();
            var color = Microsoft.Xna.Framework.Color.White;

            var flip = SpriteEffects.None;

            spriteBatch.Draw(texture, destRec, srcRec, color, 0, Vector2.Zero, flip, 0);
        }
    }
}
