using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services.Interfaces;
using NSubstitute;

namespace Clockwork.Tests.MockFactories
{
    public class ICameraProviderFactory
    {
        public static ICameraProvider Create()
        {
            return Create(new Camera(new Size(320, 240)));
        }

        public static ICameraProvider Create(Camera camera)
        {
            var mock = Substitute.For<ICameraProvider>();

            mock
                .GetCameraForScene(Arg.Any<Scene>())
                .Returns(c =>
                {
                    return camera;
                });

            return mock;
        }
    }
}
