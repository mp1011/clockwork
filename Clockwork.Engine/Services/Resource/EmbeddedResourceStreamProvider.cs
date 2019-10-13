using System.IO;
using System.Linq;
using System.Reflection;
using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.Resource
{
    public class EmbeddedResourceStreamProvider : IResourceStreamProvider
    {
        private Assembly _assembly;
        private string[] _resourceNames;

        public EmbeddedResourceStreamProvider()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _resourceNames = _assembly.GetManifestResourceNames();
        }

        public bool SupportsType<T>()
        {
            return typeof(IConfig).IsAssignableFrom(typeof(T));
        }

        private string GetFolder<T>()
        {
            var folder = typeof(T).Name;
            if (folder.EndsWith("Config"))
                folder = folder.Replace("Config", "");
            return folder + "s";
        }

        public Stream GetStream<T>(string key)
        {
            var suffix = $"{GetFolder<T>()}.{key}.config";

            var name = _resourceNames.Single(p => p.EndsWith(suffix));
            return _assembly.GetManifestResourceStream(name);
        }
    }
}
