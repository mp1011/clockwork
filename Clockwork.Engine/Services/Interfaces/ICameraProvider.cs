using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface ICameraProvider
    {
        Camera GetCameraForScene(Scene scene);
    }
}
