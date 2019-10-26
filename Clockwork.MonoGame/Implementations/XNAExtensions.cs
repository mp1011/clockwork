using Microsoft.Xna.Framework;

namespace Clockwork.MonoGame.Implementations
{
    public static class XNAExtensions
    {
        public static Rectangle ToXNARec(this Clockwork.Engine.Models.General.Rectangle r)
        {
            return new Rectangle((int)r.Left, (int)r.Top, (int)r.Width, (int)r.Height);
        }
    }
}
