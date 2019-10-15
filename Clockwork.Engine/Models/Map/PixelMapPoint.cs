using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Map
{
    public class PixelMapPoint : IWithGridPosition
    {
        public Color Color { get; }

        public Point Position { get; }

        public string[] Tags { get; } 

        public PixelMapPoint(Color color, Point position, string[] tags)
        {
            Color = color;
            Position = position;
            Tags = tags;
        }

        public override string ToString()
        {
            return $"{Position}:{Color}";
        }

    }
}
