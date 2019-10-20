namespace Clockwork.Engine.Models.Scene
{
    public class Scene
    {
        public DisplayLayer[] Layers { get; }

        public Scene(DisplayLayer[] layers)
        {
            Layers = layers;
        }
    }
}
