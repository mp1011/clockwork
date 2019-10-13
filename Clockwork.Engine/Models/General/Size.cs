using Newtonsoft.Json;

namespace Clockwork.Engine.Models.General
{
    public class Size
    {
        [JsonConstructor]
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size(float width, float height)
        {
            Width = (int)width;
            Height = (int)height;
        }


        public int Width { get; }
        public int Height { get; }

        public static Size Empty { get; } = new Size(0, 0);
    }
}
