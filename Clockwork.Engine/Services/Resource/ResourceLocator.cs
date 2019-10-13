using System.IO;
using System.Linq;
using System.Reflection;

namespace Clockwork.Engine.Services.Resource
{
    public class ResourceLocator
    {
        private DirectoryInfo _contentDirectory;
        private Assembly _assembly;
        private string[] _resourceNames;

        public ResourceLocator()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _resourceNames = _assembly.GetManifestResourceNames();

#if DEBUG
            var assemblyLocation = new FileInfo(_assembly.Location);
            var folder = assemblyLocation.Directory;
            
            while(_contentDirectory == null || !_contentDirectory.Exists)
            {
                _contentDirectory = new DirectoryInfo(Path.Combine(folder.FullName, "Clockwork.Engine", "Content"));
                folder = folder.Parent;
            }
#endif
        }

        public Stream GetStream<T>(string key)
        {
            var suffix = $"{GetFolder<T>()}.{key}.config";

            var name = _resourceNames.Single(p => p.EndsWith(suffix));
            return _assembly.GetManifestResourceStream(name);
        }

        private string GetFolder<T>()
        {
            var folder = typeof(T).Name;
            if (folder.EndsWith("Config"))
                folder = folder.Replace("Config", "s");
            return folder;
        }

        public FileInfo GetDevelopmentFilePath<T>(string key)
        {
#if DEBUG
            string path = Path.Combine(_contentDirectory.FullName, GetFolder<T>(), key);
            return new FileInfo(path + ".config");
#else

            throw new NotSupportedException("Development file paths are not supported in Release configuration");
#endif
        }

    }
}
