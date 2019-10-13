using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Resource;
using Clockwork.Engine.Services.Interfaces;
using System.IO;

namespace Clockwork.Engine.Services.Resource
{
    public class BitmapTextureLoader : ITextureLoader
    {
        private readonly ResourceService _resourceService;

        public BitmapTextureLoader(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public ArrayGrid<Color> LoadPixels(string key)
        {
            ArrayGrid<Color> colors = null;

            using (var stream = _resourceService.GetStream<Texture>(key))
            {
                using (var bitmap = new System.Drawing.Bitmap(stream))
                {
                    colors = new ArrayGrid<Color>(bitmap.Width, bitmap.Height);
                    colors.Fill(pt =>
                    {
                        var color = bitmap.GetPixel(pt.X, pt.Y);
                        return new Color(color.R, color.G, color.B);
                    });

                }
            }

            return colors;
        }
    }
}
