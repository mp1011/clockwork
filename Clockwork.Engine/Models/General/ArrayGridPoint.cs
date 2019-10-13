using Clockwork.Engine.Extensions;
using System.Collections.Generic;
using System.Numerics;

namespace Clockwork.Engine.Models.General
{
    public class ArrayGridPoint<T>
    {
        public ArrayGrid<T> Grid;
        public Point Position;
        public int Index => Grid.PointToIndex(Position, 0);

        public T Value;

        public override string ToString()
        {
            return $"{Position.X},{Position.Y}={Value}";
        }

        public ArrayGridPoint(Point position, ArrayGrid<T> grid)
        {
            Grid = grid;
            Value = grid.GetFromPoint(position);
            Position = position;
        }

        public ArrayGridPoint<T> GetAdjacent(Direction side)
        {
            var adj = Position.GetAdjacent(side);
            return new ArrayGridPoint<T>(adj, Grid);
        }

        public ArrayGridPoint<T> GetAdjacent(BorderSide side)
        {
            var adj = Position.GetAdjacent(side);
            return new ArrayGridPoint<T>(adj, Grid);
        }

        public IEnumerable<ArrayGridPoint<T>> GetAdjacent()
        {
            yield return GetAdjacent(Direction.Left);
            yield return GetAdjacent(Direction.Right);
            yield return GetAdjacent(Direction.Up);
            yield return GetAdjacent(Direction.Down);
        }

        public void Set(T value)
        {
            Grid.Set(Position, value);
        }
    }


}
