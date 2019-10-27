using Clockwork.Engine.Extensions;
using Clockwork.Engine.Models.GameObjectInterfaces;
using System;
using System.Collections.Generic;

namespace Clockwork.Engine.Services
{
    public class MotionManager
    {
        private readonly ICollection<IMoveable> _movingObjects = new List<IMoveable>();

        public void AddObject(IMoveable m)
        {
            _movingObjects.Add(m);
        }

        public void ApplyMotion(TimeSpan elapsed)
        {
            foreach(var movingObject in _movingObjects)
            {
                var vector = movingObject
                    .MotionVector
                    .VectorPerSecond
                    .Scale(elapsed.TotalSeconds);

                movingObject.Position.Translate(vector.X, vector.Y);
            }
        }
    }
}
