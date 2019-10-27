using Clockwork.Engine.Models.General;
using System.Linq;

namespace Clockwork.Engine.Models.Scene
{
    public class Scene
    {
        public DisplayLayer[] Layers { get; }

        public Size Bounds { get; }

        public Scene(params DisplayLayer[] layers)
        {
            Layers = layers;

            var maxWidth = layers.Max(p => p.Position.Width);
            var maxHeight = layers.Max(p => p.Position.Height);
            Bounds = new Size(maxWidth, maxHeight);
        }
    }
}
