using Clockwork.Engine.Extensions;
using System.Numerics;

namespace Clockwork.Engine.Models.General
{
    public class Angle
    {
        public Vector2 UnitVector { get; set; } = Vector2.One;

        public void SetDegrees(float degrees)
        {
            UnitVector = degrees.DegreesToVector(1);
        }
    }
}
