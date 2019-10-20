using Clockwork.Engine;
using Clockwork.Engine.Services.Graphics;
using NUnit.Framework;

namespace Clockwork.Tests
{
    [TestFixture]
    class TestBase
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DIRegistrar.EngineAssembly = typeof(BitmapTexturePainter).Assembly;
        }
    }
}
