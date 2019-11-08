using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Engine.Models.Graphics
{
    public class SpriteSheet
    {
        private readonly ITextureSection[] _sections;

        public SpriteSheet(IEnumerable<ITextureSection> sections)
        {
            _sections = sections.ToArray();
        }

        public ITextureSection this[int index]
        {
            get
            {
                return _sections[index];
            }
        }
    }
}
