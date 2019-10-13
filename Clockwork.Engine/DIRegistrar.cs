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
                });
            }));

        }
        public static T GetInstance<T>()
        {
            return GetContainer().GetInstance<T>();
        }
    }
}
