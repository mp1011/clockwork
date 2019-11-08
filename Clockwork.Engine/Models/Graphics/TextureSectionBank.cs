using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Graphics
{
    public class TextureSectionBank : Bank<TextureSection>, ITextureSection
    {

        public TextureSectionBank(TextureSection[] sections) : base(sections) { }

        public Point Offset => Current.Offset;
        public string TextureKey => Current.TextureKey;
        public Rectangle TextureRegion => Current.TextureRegion;

    }
}
