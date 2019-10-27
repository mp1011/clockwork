using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Models.Config
{
    public class GameConfig : IConfig
    {
        public string Name { get; set; }

        public string InitialScene { get; set; }

        public Size ViewportSize { get; set; }
    }
}
