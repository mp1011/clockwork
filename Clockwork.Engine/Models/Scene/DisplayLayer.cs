using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;

namespace Clockwork.Engine.Models.Scene
{
    public class DisplayLayer : IWithPosition
    {
        public Rectangle Position { get; }

        public IDisplayable[] DisplayItems { get; }

        public DisplayLayer(Size size, IDisplayable[] items)
        {
            Position = new Rectangle(size);
            DisplayItems = items;
        }
    }
}
