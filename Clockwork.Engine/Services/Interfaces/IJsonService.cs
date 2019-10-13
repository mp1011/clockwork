using Clockwork.Engine.Models.Config;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface IJsonService
    {
        T Read<T>(string key);
        void Write<T>(T config) where T : IConfig;
    }
}
