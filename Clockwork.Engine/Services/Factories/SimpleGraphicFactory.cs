using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.Factories
{
    public class SimpleGraphicFactory
    {
        private readonly ITextureLoader _loader;

        public SimpleGraphicFactory(ITextureLoader loader)
        {
            _loader = loader;
        }

        public SimpleGraphic Create(string textureKey)
        {
            var size = _loader.GetTextureSize(textureKey);
            return new SimpleGraphic(textureKey, new Rectangle(0, 0, size.Width, size.Height));
        }
    }
}
