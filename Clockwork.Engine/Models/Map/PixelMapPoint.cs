using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Map
{
    public class PixelMapPoint
    {
        public Color Color { get; }

        public PixelMapPoint(Color color)
        {
            Color = color;
        }
    }
}
