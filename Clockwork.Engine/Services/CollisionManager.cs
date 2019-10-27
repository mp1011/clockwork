using Clockwork.Engine.Models.GameObjectInterfaces;
using System.Collections.Generic;

namespace Clockwork.Engine.Services
{
    public class CollisionManager
    {
        private ICollection<ICollidable> _collidableObjects = new List<ICollidable>();

        public void AddObject(ICollidable collidableObject)
        {
            _collidableObjects.Add(collidableObject);
        }

        public void HandleCollisions()
        {
            foreach(var collidableObject in _collidableObjects)
            {
                collidableObject.Position.KeepWithin(collidableObject.Bounds);
            }
        }
    }
}
