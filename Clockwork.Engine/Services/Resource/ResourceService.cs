using Clockwork.Engine.Services.Interfaces;
using System.IO;
using System.Linq;

namespace Clockwork.Engine.Services.Resource
{
    public class ResourceService
    {
        private readonly IResourceLoader[] _loaders;

        public ResourceService(IResourceLoader[] loaders)
        {
            _loaders = loaders;
        }

        public T LoadResource<T>(string key=null)
        {
            var loader = _loaders.Single(p => p.SupportsType<T>());
            return loader.Load<T>(key);
        }
    }
}
