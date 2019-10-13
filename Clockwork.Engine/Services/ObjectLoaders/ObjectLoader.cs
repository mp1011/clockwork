using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public abstract class ObjectLoader<TConfig,T>
        where TConfig : IConfig
    {
        private IResourceLoader _resourceLoader;

        public ObjectLoader(IResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public T Load(string key)
        {
            var config = _resourceLoader.LoadResource<TConfig>(key);
            return Create(config);
        }

        protected abstract T Create(TConfig config);
    }
}
