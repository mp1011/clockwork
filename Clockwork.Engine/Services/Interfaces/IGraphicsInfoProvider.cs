using Clockwork.Engine.Models.General;
using StructureMap;

namespace Clockwork.Engine.Services.Interfaces
{
    [Singleton]
    public interface IGraphicsInfoProvider
    {
         Size ScreenSize { get; }

         Size ViewportSize { get; }
    }
}
