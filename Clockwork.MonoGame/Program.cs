using Clockwork.Engine;
using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Models.TileSets;
using Clockwork.Engine.Services.Interfaces;
using Clockwork.Engine.Services.Resource;

namespace Clockwork.MonoGame
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BootstrapModels();

            using (var game = new Engine.GameEngine())
                game.Run();

        }

        /// <summary>
        /// temporary method to create some starter data
        /// </summary>
        public static void BootstrapModels()
        {
            var jsonservice = DIRegistrar.GetInstance<NewtonsoftJsonService>();
            var streamProvider = DIRegistrar.GetInstance<DevelopmentFileStreamProvider>();

            jsonservice.Write(new SceneConfig
            {
                Name = "testScene",
                TileMap = "testmap"

            }, streamProvider);

            jsonservice.Write(new TileMapConfig
            {
                Name = "testmap",
                TilesetName = "forest_tiles",
            }, streamProvider);

            jsonservice.Write(new TileSetConfig
            {
                Name = "forest_tiles",
                TextureSize = new Size(160, 128),
                TileSize = new Size(16, 16),
                Tiles = new TileConfig[]
                {
                    new TileConfig { X=0, Y=0, Flags = TileFlags.Empty},
                    new TileConfig { X=1, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=1, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=2, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=3, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=4, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=5, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=6, Y=0, Flags = TileFlags.Solid},
                    new TileConfig { X=0, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=1, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=2, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=3, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=4, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=5, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=6, Y=1, Flags = TileFlags.Solid},
                    new TileConfig { X=0, Y=2, Flags = TileFlags.Solid},
                    new TileConfig { X=0, Y=2, Flags = TileFlags.Solid},
                    new TileConfig { X=4, Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=5, Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=6, Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=7, Y=7, Flags = TileFlags.Solid},
                    new TileConfig { X=8, Y=7, Flags = TileFlags.Solid}
                },
                RuleSets = new TileRuleSetConfig[]
                {
                    new TileRuleSetConfig
                    {
                        Name = "rock",
                        ExtraTags = new string[] {"solid","nonempty"},
                        MapColor = new Color(0,0,0),
                        TileRules = new TileRuleConfig[]
                        {
                            new TileRuleConfig(3,0, right: "rock", bottom: "rock", left: "background", top:"background"),
                            new TileRuleConfig(4, 0,right:"rock",bottom:"rock",left:"rock",top:"background"),
                            new TileRuleConfig(5, 0,right:"background",bottom:"rock",left:"rock",top:"background"),
                            new TileRuleConfig(6, 0,right:"background",left:"background",bottom:"rock",top:"background"),
                            new TileRuleConfig(3, 1,left:"background",top:"rock",bottom:"rock",right:"rock"),
                            new TileRuleConfig(4, 1,left:"rock",top:"rock",bottom:"rock",right:"rock"),
                            new TileRuleConfig(0, 2,left:"rock",top:"rock",bottom:"rock",right:"rock",chance:10),
                            new TileRuleConfig(5, 1,left:"rock",top:"rock",bottom:"rock",right:"background"),
                            new TileRuleConfig(6, 1,left:"background",right:"background",top:"rock",bottom:"rock"),
                            new TileRuleConfig(6, 7,left:"background",right:"rock",top:"rock",bottom:"background"),
                            new TileRuleConfig(7, 7,left:"rock",right:"rock",top:"rock",bottom:"background"),
                            new TileRuleConfig(8, 7,left:"rock",right:"background",bottom:"background",top:"rock"),
                            new TileRuleConfig(5, 5,right:"grass",layer:TileLayer.Undercell),
                            new TileRuleConfig(5, 5,left:"grass",layer:TileLayer.Undercell),
                            new TileRuleConfig(5, 4,right:"grass",topLeft:"empty",layer:TileLayer.Undercell),
                            new TileRuleConfig(5, 4,right:"grass",topRight:"empty",layer:TileLayer.Undercell),
                            new TileRuleConfig(5, 6,right:"grass",bottomLeft:"empty",layer:TileLayer.Undercell),
                            new TileRuleConfig(5, 6,right:"grass",bottomRight:"empty",layer:TileLayer.Undercell),
                            new TileRuleConfig(4, 7,left:"rock",right:"rock",top:"rock",bottom:"rock",topLeft:"background"),
                            new TileRuleConfig(5, 7,left:"rock",right:"rock",top:"rock",bottom:"rock",topRight:"background")
                        }
                    },
                    new TileRuleSetConfig
                    {
                        Name="grassrock",
                        ExtraTags = new string[]{"solid","nonempty","rock" },
                        MapColor = new Color(0,128,0),
                        TileRules= new TileRuleConfig[]
                        {
                            new TileRuleConfig(2, 0,left:"grassrock",right:"rock",bottom:"rock"),
                            new TileRuleConfig(0, 1,left:"rock",right:"grassrock",bottom:"rock"),
                            new TileRuleConfig(2, 1,left:"grassrock",right:"background",bottom:"rock"),
                            new TileRuleConfig(1, 0,left:"grassrock",right:"grassrock",bottom:"rock"),
                            new TileRuleConfig(1, 1,left:"background",right:"grassrock",bottom:"rock")
                        }
                    },
                    new TileRuleSetConfig
                    {
                        Name = "grass",
                        ExtraTags= new string[]{"background","nonempty"},
                        MapColor = new Color(0,255,0),
                        TileRules = new TileRuleConfig[]
                        {
                            new TileRuleConfig(4, 4,left:"empty",top:"empty",bottom:"nonempty",right:"nonempty"),
                            new TileRuleConfig(5, 4,left:"nonempty",top:"empty",bottom:"nonempty",right:"nonempty"),
                            new TileRuleConfig(6, 4,left:"nonempty",top:"empty",bottom:"nonempty",right:"empty"),
                            new TileRuleConfig(4, 5,left:"empty",top:"nonempty",bottom:"nonempty",right:"nonempty"),
                            new TileRuleConfig(5, 5,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty"),
                            new TileRuleConfig(2, 6,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty",chance:10),
                            new TileRuleConfig(3, 6,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty",chance:10),
                            new TileRuleConfig(6, 5,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"empty"),
                            new TileRuleConfig(4, 6,left:"empty",top:"nonempty",bottom:"empty",right:"nonempty"),
                            new TileRuleConfig(5, 6,left:"nonempty",top:"nonempty",bottom:"empty",right:"nonempty"),
                            new TileRuleConfig(6, 6,left:"nonempty",top:"nonempty",bottom:"empty",right:"empty"),
                            new TileRuleConfig(2, 4,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty",bottomRight:"empty"),
                            new TileRuleConfig(3, 4,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty",bottomLeft:"empty"),
                            new TileRuleConfig(2, 5,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty",topRight:"empty"),
                            new TileRuleConfig(3, 5,left:"nonempty",top:"nonempty",bottom:"nonempty",right:"nonempty",topLeft:"empty")
                        }
                    },
                    new TileRuleSetConfig
                    {
                        Name = "decoration",
                        TileRules = new TileRuleConfig[]
                        {
                            new TileRuleConfig(4, 3,bottom:"grassrock",layer:TileLayer.Overcell,chance:90),
                            new TileRuleConfig(7, 5,bottom:"grassrock",layer:TileLayer.Overcell,chance:10),
                            new TileRuleConfig(8, 5,bottom:"grassrock",layer:TileLayer.Overcell,chance:10),
                            new TileRuleConfig(7, 6,bottom:"grassrock",layer:TileLayer.Overcell,chance:10),
                            new TileRuleConfig(8, 6,bottom:"grassrock",layer:TileLayer.Overcell,chance:10),
                            new TileRuleConfig(9, 5,self:"background",bottom:"rock",layer:TileLayer.Overcell,chance:2),
                            new TileRuleConfig(9, 6,self:"background",bottom:"rock",layer:TileLayer.Overcell,chance:3),
                        }
                    }
                }
            }, streamProvider);

        }
    }
}
