using Clockwork.Engine.Models.General;
using Clockwork.Engine.Models.Interfaces;
using System.Linq;
using System.Numerics;

namespace Clockwork.Engine.Extensions
{
    public static class DirectionExtensions
    {
        public static BorderSide ToSide(this Direction d)
        {
            switch (d)
            {
                case Direction.Left: return BorderSide.Left;
                case Direction.Right: return BorderSide.Right;
                case Direction.Up: return BorderSide.Top;
                case Direction.Down: return BorderSide.Bottom;
                default: return BorderSide.None;
            }
        }

        public static int ToFlipMod(this Direction d)
        {
            if (d == Direction.Left)
                return -1;
            else
                return 1;
        }

        public static Direction Opposite(this Direction d)
        {
            switch (d)
            {
                case Direction.Down: return Direction.Up;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                case Direction.Up: return Direction.Down;
                default:
                    return d;
            }
        }

        public static Direction CardinalDirectionTowards(this IWithPosition thisObject, IWithPosition other, Axis axis = Models.General.Axis.Any)
        {
            var thisPos = thisObject.Position.Center;
            var otherPos = other.Position.Center;

            bool right = thisPos.X < otherPos.X;
            bool left = thisPos.X > otherPos.X;
            bool down = thisPos.Y < otherPos.Y;
            bool up = thisPos.Y > otherPos.Y;

            if (axis == Models.General.Axis.X)
            {
                if (left)
                    return Direction.Left;
                else
                    return Direction.Right;
            }
            else if (axis == Models.General.Axis.Y)
            {
                if (up)
                    return Direction.Up;
                else
                    return Direction.Down;
            }
            else
            {
                if (left && !up && !down)
                    return Direction.Left;
                else if (right && !up && !down)
                    return Direction.Right;
                else if (down && !left && !right)
                    return Direction.Down;
                else if (up && !left && !right)
                    return Direction.Up;
                else
                    return Direction.None;
            }

        }

        public static Direction DirectionAwayFrom(this IWithPosition thisObject, IWithPosition other, Axis axis)
        {
            return thisObject.CardinalDirectionTowards(other, axis).Opposite();
        }

        public static Axis Axis(this Direction d)
        {
            switch (d)
            {
                case Direction.Down: return Models.General.Axis.Y;
                case Direction.Up: return Models.General.Axis.Y;
                default:
                    return Models.General.Axis.X;
            }
        }

        public static Vector2 ToXY(this Direction d)
        {
            switch (d)
            {
                case Direction.Down: return new Vector2(0, 1);
                case Direction.Left: return new Vector2(-1, 0);
                case Direction.Right: return new Vector2(1, 0);
                case Direction.Up: return new Vector2(0, -1);
                default:
                    return Vector2.Zero;
            }
        }
    }

}
