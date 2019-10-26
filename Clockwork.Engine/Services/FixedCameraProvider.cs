using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.Engine.Services
{
    public class FixedCameraProvider : ICameraProvider
    {
        private Camera _camera;
        private IGraphicsInfoProvider _graphicsInfoProvider;

        public FixedCameraProvider(IGraphicsInfoProvider graphicsInfoProvider)
        {
            _graphicsInfoProvider = graphicsInfoProvider;
        }

        public Camera GetCameraForScene(Scene scene)
        {
            return _camera ?? (_camera = new Camera(_graphicsInfoProvider.ScreenSize));
        }
    }
}
