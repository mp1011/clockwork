using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Config
{
    public class TileRuleSetConfig : IConfig
    {
        public string Name { get; set; }

        public string[] ExtraTags { get; set; }

        public Color MapColor { get; set; }

        public TileRuleConfig[] TileRules { get; set; }

    }
}
