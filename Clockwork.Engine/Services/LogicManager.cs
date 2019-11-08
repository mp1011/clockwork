using Clockwork.Engine.Behaviors;
using Clockwork.Engine.Models.GameObjectInterfaces;
using Clockwork.Engine.Models.Graphics;
using System;

namespace Clockwork.Engine.Services
{
    public class LogicManager
    {
        private readonly InputManager _inputManager;
        private readonly MotionManager _motionManager;
        private readonly CollisionManager _collisionManager;
        private readonly BehaviorManager _behaviorManager;
        private readonly AnimationManager _animationManager;

        public LogicManager(InputManager inputManager, MotionManager motionManager, CollisionManager collisionManager, 
            BehaviorManager behaviorManager, AnimationManager animationManager)
        {
            _inputManager = inputManager;
            _motionManager = motionManager;
            _collisionManager = collisionManager;
            _behaviorManager = behaviorManager;
            _animationManager = animationManager;
        }

        public void Update(TimeSpan elapsed)
        {
            _inputManager.CollectInput();
            _behaviorManager.Update(elapsed);
            _motionManager.ApplyMotion(elapsed);
            _collisionManager.HandleCollisions();
            _animationManager.Update(elapsed);
        }

        public void Add(IGameObject gameObject)
        {

            if (gameObject is IMoveable m)
                _motionManager.AddObject(m);

            if (gameObject is ICollidable c)
                _collisionManager.AddObject(c);

            if (gameObject is IBehavior b)
                _behaviorManager.Add(b);

            if (gameObject is Animation a)
                _animationManager.Add(a);

        }
    }
}
