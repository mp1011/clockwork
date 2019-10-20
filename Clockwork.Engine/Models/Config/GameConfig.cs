namespace Clockwork.Engine.Models.Config
{
    public class GameConfig : IConfig
    {
        public string Name { get; set; } = "Game";

        public string InitialScene { get; set; }
    }
}
