using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.Scene;
using Clockwork.Engine.Services.ObjectLoaders;
using Clockwork.Engine.Services.Resource;

namespace Clockwork.Engine.Services
{
    public class SceneManager
    {

        private readonly SceneLoader _loader;
        private readonly GameConfig _config;
        private Scene _current;
        public SceneManager(SceneLoader loader, ResourceService resourceService)
        {
            _loader = loader;
            _config = resourceService.LoadResource<GameConfig>();
        }

        public Scene LoadInitialScene()
        {
            return (_current = _loader.Load(_config.InitialScene));
        }

        public Scene GetCurrentScene()
        {
            return _current;
        }
    }
}
