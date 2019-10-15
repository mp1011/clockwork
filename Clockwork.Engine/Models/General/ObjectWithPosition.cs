namespace Clockwork.Engine.Models.General
{
    public class ObjectWithPosition<T> : IWithGridPosition
    {
        public Point Position { get; }
        public T Item { get;
        }
        public ObjectWithPosition(T item, Point position)
        {
            Item = item;
            Position = position;
        }
    }
}
