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

        public Size GetTextureSize(string key)
        {
            using (var bitmap = _resourceService.LoadResource<System.Drawing.Bitmap>(key))
            {
                return new Size(bitmap.Width, bitmap.Height);
            }
        }

        public ArrayGrid<ObjectWithPosition<Color>> LoadPixels(string key)
        {

            ArrayGrid<ObjectWithPosition<Color>> colors = null;

            using (var bitmap = _resourceService.LoadResource<System.Drawing.Bitmap>(key))
            {
                colors = new ArrayGrid<ObjectWithPosition<Color>>(bitmap.Width, bitmap.Height);
                colors.Fill(pt =>
                {
                    var color = bitmap.GetPixel(pt.X, pt.Y);
                    return new ObjectWithPosition<Color>(new Color(color.R, color.G, color.B), pt);
                });
            }

            return colors;
        }
    }
}
