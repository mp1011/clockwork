using Clockwork.Engine.Models.General;
using Clockwork.Engine.Services.Interfaces;
using NSubstitute;
using System;

namespace Clockwork.Tests.MockFactories
{
    public static class ITexturePainterMockFactory
    {

        public static ITexturePainter Create(Action<string, Rectangle,Rectangle> callback)
        {
            var mock = Substitute.For<ITexturePainter>();

            mock.WhenForAnyArgs(m=>m.DrawTextureRegion(null,null,null))
                .Do(x =>
                {
                    var texture = x.ArgAt<string>(0);
                    var textureRegion = x.ArgAt<Rectangle>(1);
                    var destination = x.ArgAt<Rectangle>(2);

                    callback(texture, textureRegion, destination);
                });

            return mock;
        }
    }
}
