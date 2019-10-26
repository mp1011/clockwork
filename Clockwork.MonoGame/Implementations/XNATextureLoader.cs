using Clockwork.Engine.Models.General;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.MonoGame.Engine;
using Microsoft.Xna.Framework.Graphics;
using XNAColor = Microsoft.Xna.Framework.Color;
using Color = Clockwork.Engine.Models.General.Color;
using System.Linq;

namespace Clockwork.MonoGame.Implementations
{
    public class XNATextureLoader : ITextureLoader<Texture2D>
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

        public Texture2D LoadTexture(string key)
        {
            return _textureLoader.Load<Texture2D>(key);
        }


        public ArrayGrid<ObjectWithPosition<Color>> LoadPixels(string key)
        {
            var texture = _textureLoader.Load<Texture2D>(key);
            XNAColor[] data = new XNAColor[texture.Width * texture.Height];
            texture.GetData(data);

            Point point = new Point(-1, 0);
            var colors = data
                .Select(c => new Color(c.R, c.G, c.B))
                .Select(c =>
                {
                    point = point.GridStep(texture.Width);
                    return new ObjectWithPosition<Color>(item: c, point);
                })
                .ToArray();

            var ret = new ArrayGrid<ObjectWithPosition<Color>>(texture.Width, colors);
            return ret;
        }
    }
}
