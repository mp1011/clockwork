using Clockwork.Engine.Services.Interfaces;
using System.IO;
using System.Linq;

namespace Clockwork.Engine.Services.Resource
{
    public class ResourceService
    {
        private readonly IResourceLoader[] _loaders;
        private readonly IResourceStreamProvider[] _streamProviders;

        public ResourceService(IResourceLoader[] loaders, IResourceStreamProvider[] streamProviders)
        {
            _loaders = loaders;
            _streamProviders = streamProviders;
        }

        public Stream GetStream<T>(string key)
        {
            var provider = _streamProviders.Single(p => p.SupportsType<T>());
            return provider.GetStream<T>(key);
        }

        public T LoadResource<T>(string key)
        {
            var loader = _loaders.Single(p => p.SupportsType<T>());

            using (var stream = GetStream<T>(key))
            {
                var item = loader.Load<T>(stream);
                return item;
            }
        }
    }
}
