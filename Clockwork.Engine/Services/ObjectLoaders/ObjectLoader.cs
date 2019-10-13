using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;

namespace Clockwork.Engine.Services.ObjectLoaders
{
    public abstract class ObjectLoader<TConfig,T>
        where TConfig : IConfig
    {
        private readonly ResourceService _resourceService;

        public ObjectLoader(ResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public T Load(string key)
        {
            var config = _resourceService.LoadResource<TConfig>(key);
            return Create(config);
        }

        protected abstract T Create(TConfig config);
    }
}
