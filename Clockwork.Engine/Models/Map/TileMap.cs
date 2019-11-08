using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Graphics;
using Clockwork.Engine.Models.TileSets;
using System.Linq;

namespace Clockwork.Engine.Models.Map
{
    public class TileMap : IDisplayable
    {
        public ArrayGrid<Tile> Grid { get; }

        public ITextureSection[] Textures { get; }

        public Rectangle Position { get; }

        public TileMap(TileMapConfig config, TileSet tileSet, ArrayGrid<Tile> grid)
        {
            Grid = grid;

            Textures = grid
                .Select(tile =>
                {
                    var textureRegion = new Rectangle(tile.Description.GridPosition.Scale(tileSet.TileSize), tileSet.TileSize);
                    var worldPosition = tile.GridPosition.Scale(tileSet.TileSize);
                    return new TextureSection(config.TilesetName, textureRegion, worldPosition);
                })
                .ToArray();

            Position = new Rectangle(Point.Zero, grid.GridSize.Scale(tileSet.TileSize));
        }
    }
}
