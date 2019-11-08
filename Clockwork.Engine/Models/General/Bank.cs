using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Engine.Models.General
{
    public class Bank<T>
    {
        private T[] _list;
        public ModularInteger Index { get; set; }

        public Bank(IEnumerable<T> items)
        {
            _list = items.ToArray();
            Index = new ModularInteger(_list.Length);
        }

        public T Current => _list[Index];
    }
}
