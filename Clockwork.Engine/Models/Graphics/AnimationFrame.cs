using System;
using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Graphics
{
    public class AnimationFrame : ITextureSection
    {
        public TimeSpan Duration { get; }
        private ITextureSection _texture;

        public string TextureKey => _texture.TextureKey;

        public Rectangle TextureRegion => _texture.TextureRegion;

        public Point Offset => _texture.Offset;

        public AnimationFrame(TimeSpan duration, ITextureSection texture)
        {
            Duration = duration;
            _texture = texture;
        }
    }
}
