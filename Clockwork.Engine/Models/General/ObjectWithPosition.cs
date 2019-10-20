namespace Clockwork.Engine.Models.General
{
    public class ObjectWithPosition<T> : IWithGridPosition
    {
        public Point GridPosition { get; }
        public T Item { get;
        }
        public ObjectWithPosition(T item, Point position)
        {
            Item = item;
            GridPosition = position;
        }
    }
}
