using Clockwork.Engine.Extensions;
using System.Numerics;

namespace Clockwork.Engine.Models.General
{
    public class MotionVector
    {
        public Vector2 VectorPerSecond => Angle.UnitVector.Scale(MagnitudePerSecond);
        
        public float MagnitudePerSecond { get; set; }

        public Angle Angle { get; } = new Angle();
    }
}
