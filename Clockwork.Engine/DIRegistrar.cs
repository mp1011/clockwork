﻿using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;
using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Clockwork.Engine
{
    public class DIRegistrar
    {
        private static Container _container;

        public static Assembly EngineAssembly { get; set; }

        public static Action<ConfigurationExpression> CustomBindings { get; set; }

        private static Container GetContainer()
        {
            return _container ?? (_container = new Container(c =>
            {
                c.Scan(o =>
                {
                    o.TheCallingAssembly();
                    if (EngineAssembly != null)
                        o.Assembly(EngineAssembly);

                    o.WithDefaultConventions();
                    o.RegisterConcreteTypesAgainstTheFirstInterface();
                    
                    o.AddAllTypesOf<IResourceLoader>();
                    o.AddAllTypesOf<IResourceStreamProvider>();
                });


                CustomBindings?.Invoke(c);

            }));
        }

       
        public static T GetInstance<T>()
        {
            return GetContainer().GetInstance<T>();
        }
    }
}
