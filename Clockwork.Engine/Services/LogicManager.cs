using System;

namespace Clockwork.Engine.Services
{
    public class LogicManager
    {
        private readonly InputManager _inputManager;
        private readonly MotionManager _motionManager;
        private readonly CollisionManager _collisionManager;
        private readonly BehaviorManager _behaviorManager;

        public LogicManager(InputManager inputManager, MotionManager motionManager, CollisionManager collisionManager, BehaviorManager behaviorManager)
        {
            _inputManager = inputManager;
            _motionManager = motionManager;
            _collisionManager = collisionManager;
            _behaviorManager = behaviorManager;
        }

        public void Update(TimeSpan elapsed)
        {
            _inputManager.CollectInput();
            _motionManager.ApplyMotion(elapsed);
            _collisionManager.HandleCollisions();
            _behaviorManager.ApplyBehaviors(elapsed);
        }
    }
}
