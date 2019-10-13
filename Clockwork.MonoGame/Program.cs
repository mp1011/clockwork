using Clockwork.Engine;
using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Services.Interfaces;

namespace Clockwork.MonoGame
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BootstrapModels();
        }

        /// <summary>
        /// temporary method to create some starter data
        /// </summary>
        public static void BootstrapModels()
        {
            var jsonservice = DIRegistrar.GetInstance<IJsonService>();

            jsonservice.Write(new TileMapConfig { Name = "testmap" });

            jsonservice.Write(new TilesetConfig
            {
                Name = "forest_tiles",
                TextureSize = new Size(160, 128),
                TileSize = new Size(16, 16),
                Tiles = new TileConfig[]
                {
                    new TileConfig { X=1,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=1,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=2,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=3,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=4,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=5,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=6,Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=0,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=1,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=2,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=3,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=4,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=5,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=6,Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=0,Y=2, Flags = TileFlags.Solid},
                    new TileConfig { X=0,Y=2, Flags = TileFlags.Solid},
                    new TileConfig { X=4,Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=5,Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=6,Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=7,Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=8,Y=7, Flags = TileFlags.Solid}
                }
            });

        }
    }
}
