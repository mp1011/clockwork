using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.Resource
{
    public class ResourceLoader : IResourceLoader
    {
        private readonly IJsonService _jsonService;

        public ResourceLoader(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public T LoadResource<T>(string name)
        {
            return _jsonService.Read<T>(name);
        }
    }
}
