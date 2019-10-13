using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface ITextureLoader
    {
        ArrayGrid<Color> LoadPixels(string key);
    }
}
