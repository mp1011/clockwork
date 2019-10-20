using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Map
{
    public class PixelMapPoint : IWithGridPosition
    {
        public Color Color { get; }

        public Point GridPosition { get; }

        public string[] Tags { get; } 

        public PixelMapPoint(Color color, Point position, string[] tags)
        {
            Color = color;
            GridPosition = position;
            Tags = tags;
        }

        public override string ToString()
        {
            return $"{GridPosition}:{Color}";
        }

    }
}
