using System.IO;
using System.Linq;
using System.Reflection;
using Clockwork.Engine.Models.Resource;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.Resource
{
    public class DevelopmentFileStreamProvider : IResourceStreamProvider
    {
        private DirectoryInfo _contentDirectory;
       
        public DevelopmentFileStreamProvider()
        {
#if DEBUG
            var assemblyLocation = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var folder = assemblyLocation.Directory;

            while (_contentDirectory == null || !_contentDirectory.Exists)
            {
                _contentDirectory = new DirectoryInfo(Path.Combine(folder.FullName, "Clockwork.Engine", "Content"));
                folder = folder.Parent;
            }
#endif
        }

        public bool SupportsType<T>()
        {
            return typeof(Texture).IsAssignableFrom(typeof(T));
        }

        private string GetFolder<T>()
        {
            var folder = typeof(T).Name;
            if (folder.EndsWith("Config"))
                folder = folder.Replace("Config", "");
            return folder + "s";
        }

        public FileInfo GetDevelopmentFilePath<T>(string key)
        {
#if DEBUG
            var folder = new DirectoryInfo(Path.Combine(_contentDirectory.FullName, GetFolder<T>()));
            return folder.GetFiles(key + ".*").Single();
#else

            throw new NotSupportedException("Development file paths are not supported in Release configuration");
#endif
        }

        public Stream GetStream<T>(string key)
        {
            var file = GetDevelopmentFilePath<T>(key);
            return file.OpenRead();
        }

        
    }
}
