using Clockwork.Engine.Behaviors;
using System;
using System.Collections.Generic;

namespace Clockwork.Engine.Services
{
    public class BehaviorManager
    {
        private ICollection<IBehavior> _behaviors = new List<IBehavior>();

        public void AddBehavior(IBehavior b)
        {
            _behaviors.Add(b);
        }

        public void ApplyBehaviors(TimeSpan elapsed)
        {
            foreach (var behavior in _behaviors)
                behavior.Update(elapsed);
        }
    }
}
