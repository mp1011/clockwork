using Clockwork.Engine.Models.Config;
using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Map;
using Clockwork.Engine.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Engine.Models.TileSets
{
    /// <summary>
    /// Defines how to place tiles based on how its neighbors are filled
    /// </summary>
    public class TilePlacementRule
    {
        private Dictionary<BorderSide, string> requiredNeighbors = new Dictionary<BorderSide, string>();
        public Point GridPoint { get; private set; }
        public TileLayer Layer { get; private set; }
        public double Chance = 1.0f;
        private string SelfMatch = null;

        public TilePlacementRule(TileRuleConfig config)
        {
            GridPoint = config.Cell;

            SelfMatch = config.Self;
            Chance = config.Chance;

            if(config.Left != null) requiredNeighbors.Add(BorderSide.Left, config.Left);
            if (config.Right != null) requiredNeighbors.Add(BorderSide.Right, config.Right);
            if (config.Bottom != null) requiredNeighbors.Add(BorderSide.Bottom, config.Bottom);
            if (config.Top != null) requiredNeighbors.Add(BorderSide.Top, config.Top);

            if (config.TopLeftCorner != null) requiredNeighbors.Add(BorderSide.TopLeftCorner, config.TopLeftCorner);
            if (config.TopRightCorner != null) requiredNeighbors.Add(BorderSide.TopRightCorner, config.TopRightCorner);
            if (config.BottomLeftCorner != null) requiredNeighbors.Add(BorderSide.BottomLeftCorner, config.BottomLeftCorner);
            if (config.BottomRightCorner != null) requiredNeighbors.Add(BorderSide.BottomRightCorner, config.BottomRightCorner);
        }

        public TilePlacementRule(Point tileSetPoint, TileLayer layer, int percentChance, string selfMatch)
        {
            GridPoint = tileSetPoint;
            Layer = layer;
            Chance = percentChance / 100.0;
            SelfMatch = selfMatch;
        }

        public void AddSideRule(BorderSide side, string tag)
        {
            requiredNeighbors.Add(side, tag);
        }

        public bool CanApplyToPoint(ArrayGrid<PixelMapPoint> map, PixelMapPoint mapPoint)
        {
            if (SelfMatch != null)
            {
                if (!mapPoint.Tags.Contains(SelfMatch))
                    return false;
            }

            foreach (var side in requiredNeighbors.Keys)
            {
                var neighbor = map.GetFromPoint(mapPoint.GridPosition.GetAdjacent(side));
                if (neighbor != null)
                {
                    var requiredNeighborTags = requiredNeighbors[side];
                    if (!neighbor.Tags.Contains(requiredNeighborTags))
                        return false;
                }
            }

            return true;
        }

        public Tile Apply(Tile current, TileSet tileSet)
        {
            var tileDescription = tileSet.GetFromPoint(GridPoint);

            if (tileDescription == null)
                return current;

            switch (Layer)
            {
                case TileLayer.Undercell:
                    //return current.AddUndercell(tile.Cell);
                    throw new System.NotImplementedException();
                case TileLayer.Overcell:
                    throw new System.NotImplementedException();
                    //{
                    //    if (current.UnderCell > 0)
                    //    {
                    //        current.Cell = tile.Cell;
                    //        return current;
                    //    }
                    //    var ret = current.AddUndercell(current.Cell);
                    //    ret.Cell = tile.Cell;
                    //    return ret;
                    //}
                default:
                    return new Tile(current.GridPosition, tileDescription);
            }

        }
    }
}
