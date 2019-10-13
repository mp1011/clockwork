using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Config
{
    public class TilesetConfig : IConfig
    {
        public string Name { get; set; }
        public Size TextureSize { get; set; }
        public Size TileSize { get; set; }

        public TileConfig[] Tiles { get; set; }
    }
}
