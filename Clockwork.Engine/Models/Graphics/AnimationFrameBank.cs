using Clockwork.Engine.Models.General;
using System.Collections.Generic;

namespace Clockwork.Engine.Models.Graphics
{
    public class AnimationFrameBank : Bank<AnimationFrame>, ITextureSection
    {
        public AnimationFrameBank(IEnumerable<AnimationFrame> items) : base(items)
        {
        }

        public string TextureKey => Current.TextureKey;

        public Rectangle TextureRegion => Current.TextureRegion;

        public Point Offset => Current.Offset;
    }
}
