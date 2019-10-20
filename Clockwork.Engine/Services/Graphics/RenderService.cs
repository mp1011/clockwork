using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.Scene;

namespace Clockwork.Engine.Services.Graphics
{
    public class RenderService
    {

        private ITexturePainter _texturePainter;

        public RenderService(ITexturePainter texturePainter)
        {
            _texturePainter = texturePainter;
        }

        public void RenderScene(Camera camera, Scene scene)
        {
            foreach(var layer in scene.Layers)
            {
                foreach(var displayable in layer.DisplayItems)
                {
                    RenderObject(camera, displayable);
                }
            }
        }

        public void RenderObject(Camera camera, IDisplayable obj)
        {
            var objectScreenPosition = camera.GetScreenPosition(obj.Position);

            foreach (var texture in obj.Textures)
            {
                var textureScreenPosition = new Rectangle(
                    x: objectScreenPosition.UpperLeft.X + texture.Offset.X,
                    y: objectScreenPosition.UpperLeft.Y + texture.Offset.Y,
                    w:texture.TextureRegion.Width,
                    h: texture.TextureRegion.Height);

                if(textureScreenPosition.CollidesWith(camera.Position))
                    _texturePainter.DrawTextureRegion(texture.TextureKey, texture.TextureRegion, textureScreenPosition);
            }
        }
    }
}
