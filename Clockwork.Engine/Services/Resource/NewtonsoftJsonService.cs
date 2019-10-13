using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;

namespace Clockwork.Engine.Services.Resource
{
    public class NewtonsoftJsonService : IResourceLoader
    {
        public bool SupportsType<T>()
        {
            return typeof(IConfig).IsAssignableFrom(typeof(T));
        }

        public T Load<T>(Stream stream) 
        {
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var item = JsonConvert.DeserializeObject<T>(json);
                return item;
            }
        }

        public void Write<T>(T config) where T : IConfig
        {
            throw new System.NotImplementedException();
            //var key = config.Name;
            //var path = _resourceLocator.GetDevelopmentFilePath<T>(key);
            //var json = JsonConvert.SerializeObject(config);
            //File.WriteAllText(path.FullName, json);
        }
    }
}
