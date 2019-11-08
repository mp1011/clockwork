using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Services.Resource;
using System.Linq;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public class SpriteSheetLoader : ObjectLoader<SpriteSheetConfig, SpriteSheet>
    {
        public SpriteSheetLoader(ResourceService resourceService) : base(resourceService)
        {
        }

        protected override SpriteSheet Create(SpriteSheetConfig config)
        {
            var sections = config
                .Cells
                .Select(cell => 
                    new TextureSection(
                        config.Texture,
                        new Rectangle(cell.Left, cell.Top, cell.Width, cell.Height),
                        Point.Zero));

            return new SpriteSheet(sections);
        }
    }
}
