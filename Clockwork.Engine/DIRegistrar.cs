using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;
using StructureMap;

namespace Clockwork.Engine
{
    public class DIRegistrar
    {
        private static Container _container;

        private static Container GetContainer()
        {
            return _container ?? (_container = new Container(c =>
            {
                c.Scan(o =>
                {
                    o.TheCallingAssembly();
                    o.WithDefaultConventions();
                    o.RegisterConcreteTypesAgainstTheFirstInterface();

                    o.AddAllTypesOf<IResourceLoader>();
                    o.AddAllTypesOf<IResourceStreamProvider>();
                });
            }));

        }
        public static T GetInstance<T>()
        {
            return GetContainer().GetInstance<T>();
        }
    }
}
