using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services.Resource
{
    public class BitmapLoader : IResourceLoader
    {
        private IResourceStreamProvider _streamProvider;

        public BitmapLoader(DevelopmentFileStreamProvider streamProvider)
        {
            _streamProvider = streamProvider;
        }
        public T Load<T>(string resourceName)
        {
            using (var stream = _streamProvider.GetStream<T>(resourceName))
            {
                object bitmap = new System.Drawing.Bitmap(stream);
                return (T)bitmap;
            }
        }

        public bool SupportsType<T>()
        {
            return typeof(T) == typeof(System.Drawing.Bitmap);
        }
    }
}
