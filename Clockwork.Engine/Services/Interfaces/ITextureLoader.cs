﻿using Clockwork.Engine.Models.General;

namespace Clockwork.Engine.Services.Interfaces
{
    public interface ITextureLoader
    {
        ArrayGrid<ObjectWithPosition<Color>> LoadPixels(string key);
        Size GetTextureSize(string key);

    }

    public interface ITextureLoader<T> : ITextureLoader
    {
        T LoadTexture(string key);
    }
}
