namespace Clockwork.Engine.Services.Interfaces
{
    public interface IResourceLoader
    {
        T LoadResource<T>(string name);
    }
}
