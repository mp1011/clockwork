using Clockwork.Engine.Services.Interfaces;
using Clockwork.MonoGame.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace Clockwork.MonoGame.Implementations
{
    public class XNAResourceLoader : IResourceLoader
    {
        private ContentManagerProvider _managerProvider;

        public XNAResourceLoader(ContentManagerProvider provider)
        {
            _managerProvider = provider;
        }

        private string GetContentPath<T>(string key)
        {
            var folder = typeof(T).Name;
            if (typeof(T) == typeof(Texture2D))
                folder = "Texture";

            else if (folder.EndsWith("Config"))
                folder = folder.Replace("Config", "");

            return $@"{folder}s\{key}";
        }

        public bool SupportsType<T>()
        {
            return false;
        }

        public T Load<T>(string resourceName)
        {
            var path = GetContentPath<T>(resourceName);
            T ret = _managerProvider.ContentManager.Load<T>(path);
            return ret;
        }
    }
}
