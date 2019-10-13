using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace Clockwork.Engine.Services.Resource
{
    public class NewtonsoftJsonService : IJsonService
    {
        private ResourceLocator _resourceLocator;

        public NewtonsoftJsonService(ResourceLocator resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        public T Read<T>(string key)
        {
            using (var stream = _resourceLocator.GetStream<T>(key))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    var item = (T)JsonConvert.DeserializeObject(json);
                    return item;
                }
            }
        }

        public void Write<T>(T config) where T : IConfig
        {
            var key = config.Name;
            var path = _resourceLocator.GetDevelopmentFilePath<T>(key);
            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText(path.FullName, json);
        }
    }
}
