using System.IO;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface IResourceStreamProvider
    {
        Stream GetStream<T>(string key);

        bool SupportsType<T>();
    }
}
