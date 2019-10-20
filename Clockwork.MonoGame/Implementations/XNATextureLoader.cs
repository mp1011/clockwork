using Clockwork.Engine.Models.General;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.MonoGame.Engine;
using Microsoft.Xna.Framework.Graphics;
using XNAColor = Microsoft.Xna.Framework.Color;
using Color = Clockwork.Engine.Models.General.Color;
using System.Linq;

namespace Clockwork.MonoGame.Implementations
{
    public class XNATextureLoader : ITextureLoader
    {
        private IResourceLoader _textureLoader;

        public XNATextureLoader(XNAResourceLoader resourceLoader)
        {
            _textureLoader = resourceLoader;
        }

        public Size GetTextureSize(string key)
        {
            throw new System.NotImplementedException();
        }

        public ArrayGrid<ObjectWithPosition<Color>> LoadPixels(string key)
        {
            var texture = _textureLoader.Load<Texture2D>(key);
            XNAColor[] data = new XNAColor[texture.Width * texture.Height];
            texture.GetData(data);

            var colors = data
                .Select(c => new Color(c.R, c.G, c.B))
                .Select(c=> new ObjectWithPosition<Color>(item:c, Point.Zero))
                .ToArray();

            var ret = new ArrayGrid<ObjectWithPosition<Color>>(texture.Width, colors);
            return ret;
        }
    }
}
