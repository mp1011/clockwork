namespace Clockwork.Engine.Models.Config
{
    public class AnimationConfig : IConfig
    {
        public string Name { get; set; }

        public string SpriteSheet { get; set; }

        public int[] MSPerFrame { get; set; }
        
        public int[] Frames { get; set; }
    }
}
