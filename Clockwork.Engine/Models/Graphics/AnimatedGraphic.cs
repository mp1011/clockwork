using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Graphics
{
    public class AnimatedGraphic : IDisplayable
    {
        private Animation _animation;

        public ITextureSection[] Textures { get; }

        public Rectangle Position { get; } = new Rectangle(0, 0, 32, 32);

        public AnimatedGraphic(Animation animation)
        {
            _animation = animation;
            Textures = new ITextureSection[] { _animation.CurrentFrame };
        }
    }
}
