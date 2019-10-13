﻿using System.IO;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface IResourceLoader
    {
        T Load<T>(Stream resourceStream);

        bool SupportsType<T>();
    }
}
