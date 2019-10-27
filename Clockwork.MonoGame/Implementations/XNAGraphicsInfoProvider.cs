using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;
using Clockwork.MonoGame.Engine;
using FluentAssertions;
using Microsoft.Xna.Framework.Graphics;
using StructureMap;

namespace Clockwork.MonoGame.Implementations
{
    [Singleton]
    public class XNAGraphicsInfoProvider : IGraphicsInfoProvider
    {
        //wish this wasn't static but StructureMap gives me multiple instances of this class even though
        //it should be a singleton
        private static GameEngine _game;

        public Size ScreenSize => new Size(_game.Window.ClientBounds.Width, _game.Window.ClientBounds.Height);

        public Size ViewportSize { get; }

        public SpriteBatch SpriteBatch => _game.SpriteBatch;

        public XNAGraphicsInfoProvider(ResourceService resourceService)
        {
            ViewportSize = resourceService.LoadResource<GameConfig>().ViewportSize;
        }

        public void SetGame(GameEngine game)
        {
            _game = game;
        }
    }
}
