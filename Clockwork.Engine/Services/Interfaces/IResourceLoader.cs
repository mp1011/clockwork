using System.IO;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface IResourceLoader
    {
        T Load<T>(string resourceName);

        bool SupportsType<T>();
    }
}
