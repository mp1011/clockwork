using Clockwork.Engine.Models.GameObjectInterfaces;
using System;
using System.Collections.Generic;

namespace Clockwork.Engine.Services.Managers
{
    public abstract class LogicManager<T>
        where T:IUpdateable
    {
        private ICollection<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Update(TimeSpan elapsed)
        {
            foreach (var item in _items)
                item.Update(elapsed);
        }
    }
}
