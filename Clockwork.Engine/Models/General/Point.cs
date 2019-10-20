using Clockwork.Engine.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Clockwork.Engine.Models.General
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        [JsonConstructor]
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        private static Point _zero = new Point(0, 0);

        public static Point Zero => _zero;

        public Point(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public static Point IndexToXY(int index, int columns)
        {
            if (columns <= 0)
                return new Point(index, 0);

            int x = index;
            int y = 0;
            while (x >= columns)
            {
                x -= columns;
                y++;
            }
            return new Point(x, y);
        }

        public Point Translate(Vector2 v2)
        {
            return new Point(X + v2.X, Y + v2.Y);
        }

        public Point Translate(int x, int y)
        {
            return new Point(X + x, Y + y);
        }

        public Point Translate(Point v2)
        {
            return new Point(X + v2.X, Y + v2.Y);
        }

        public Point GetAdjacent(Direction dir)
        {
            return Translate(dir.ToXY());
        }

        public Point Scale(Size size)
        {
            return new Point(X * size.Width, Y * size.Height);
        }

        public Point GetAdjacent(BorderSide side)
        {
            switch (side)
            {
                case BorderSide.Top: return Translate(0, -1);
                case BorderSide.Left: return Translate(-1, 0);
                case BorderSide.Right: return Translate(1, 0);
                case BorderSide.Bottom: return Translate(0, 1);

                case BorderSide.TopLeftCorner: return Translate(-1, -1);
                case BorderSide.TopRightCorner: return Translate(1, -1);
                case BorderSide.BottomLeftCorner: return Translate(-1, 1);
                case BorderSide.BottomRightCorner: return Translate(1, 1);

                case BorderSide.None: return Translate(0, 0);

                default: throw new NotSupportedException($"Invalid border side: {side}");
            }
        }

        public Point[] GetAdjacentPoints(bool includeDiagonal)
        {
            var sides = new List<BorderSide> { BorderSide.Left, BorderSide.Top, BorderSide.Right, BorderSide.Bottom };
            if (includeDiagonal)
            {
                sides.Add(BorderSide.TopLeftCorner);
                sides.Add(BorderSide.TopRightCorner);
                sides.Add(BorderSide.BottomLeftCorner);
                sides.Add(BorderSide.BottomRightCorner);
            }

            return sides.Select(side => GetAdjacent(side)).ToArray();
        }
    }
}
