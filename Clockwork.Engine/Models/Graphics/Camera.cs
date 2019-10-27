using Clockwork.Engine.Extensions;
using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Graphics
{
    public class Camera : ICollidable
    {
        public Rectangle Position { get; }

        public Rectangle Bounds { get; }

        public Camera(Size screenSize, Rectangle bounds)
        {
            Position = new Rectangle(screenSize);
            Bounds = bounds;
        }

        public Rectangle GetScreenPosition(Rectangle worldPosition)
        {
            return new Rectangle(
                x: worldPosition.UpperLeft.X - Position.UpperLeft.X,
                y: worldPosition.UpperLeft.Y - Position.UpperLeft.Y,
                w: worldPosition.Width,
                h: worldPosition.Height);
        }
    }
}
