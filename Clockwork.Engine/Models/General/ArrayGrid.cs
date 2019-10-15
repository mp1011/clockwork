using Clockwork.Engine.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Clockwork.Engine.Models.General
{

    public class ArrayGrid<T> : IEnumerable<T>
        where T:IWithGridPosition
    {
        private T[] Items;
        public Size GridSize { get; private set; }
        public int Columns { get { return GridSize.Width; } }
        public int Rows { get { return GridSize.Height; } }

        public T OutOfBoundsFixedValue;
        public bool ReplaceOutOfBoundsTilesWithAdjacent;

        public ArrayGrid(Size size)
        {
            GridSize = size;
            Items = new T[size.Width * size.Height];
        }

        public ArrayGrid(int width, int height) : this (new Size(width,height))
        {
        }

        public ArrayGrid(int columns, IEnumerable<T> items)
        {
            Items = items.ToArray();
            if (columns == 0)
                GridSize = Size.Empty;
            else
                GridSize = new Size(columns, Items.Length / columns);
        }

        public ArrayGrid<K> Map<K>(Func<T, K> mapping)
            where K:IWithGridPosition
        {
            return new ArrayGrid<K>(Columns, Items.Select(mapping));
        }

        public void Fill(Func<T> constructor)
        {
            Fill((int i) => constructor());
        }

        public void Fill(Func<Point, T> constructor)
        {
            foreach (var pt in Points)
            {
                Set(pt, constructor(pt));
            }
        }

        public void Fill(Func<int, T> constructor)
        {
            foreach (var ix in Enumerable.Range(0, Items.Length))
            {
                Set(ix, constructor(ix));
            }
        }

        public void Set(Point point, T value)
        {
            Set(PointToIndex(point, 0), value);
        }

        public void Set(int index, T value)
        {
            Items[index] = value;
        }

        public Point IndexToPoint(int index)
        {
            return Point.IndexToXY(index, Columns);
        }

        public int PointToIndex(Point point, int outOfBoundsReturn)
        {
            if (point.X < 0 || point.Y < 0 || point.X >= Columns || point.Y >= Rows)
                return outOfBoundsReturn;

            var ret = (int)(point.Y * Columns + point.X);
            if (ret < 0)
                return outOfBoundsReturn;
            else if (ret >= Items.Length)
                return outOfBoundsReturn;
            else
                return ret;
        }

        /// <summary>
        /// Copies the given value to the range of cells
        /// </summary>
        /// <param name="block"></param>
        /// <param name="value"></param>
        public void SetBlock(Rectangle block, T value)
        {
            throw new NotImplementedException();
            //foreach (var point in block.GetPoints(new Point(1, 1)))
            //{
            //    Set(point, value);
            //}
        }

        public T GetFromPoint(int x, int y)
        {
            return GetFromPoint(new Point(x, y));
        }

        public T GetFromPoint(Point p)
        {
            var index = PointToIndex(p, -1);
            if (index == -1)
            {
                if (ReplaceOutOfBoundsTilesWithAdjacent)
                {
                    throw new System.NotImplementedException();
                    //Point adjusted = new Point(p.X.KeepInsideRange(0, GridSize.Width - 1), p.Y.KeepInsideRange(0, GridSize.Height - 1));
                    //return GetFromPoint(adjusted);
                }
                else
                    return OutOfBoundsFixedValue;
            }
            else
                return Items[index];
        }

        public T GetFromPointOrDefault(Point p)
        {
            var index = PointToIndex(p, -1);
            if (index == -1)
                return default(T);
            else
                return Items[index];
        }

        public IEnumerable<Point> Points
        {
            get
            {
                for (int y = 0; y < Rows; y++)
                {
                    for (int x = 0; x < Columns; x++)
                    {
                        yield return new Point(x, y);
                    }
                }
            }
        }

        public IEnumerable<T> GetPointsInLine(Point start, Direction dir)
        {
            Point point = start;

            while (PointToIndex(point, -1) != -1)
            {
                yield return GetFromPoint(point);
                point = point.GetAdjacent(dir);
            }

            yield return GetFromPoint(point);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        public ArrayGrid<T> ExtractBlock(Rectangle block)
        {
            float top = (float)block.Top;
            float left = (float)block.Left;
            float right = (float)block.Right;
            float bottom = (float)block.Bottom;

            top = Math.Max(0, top);
            left = Math.Max(0, left);
            right = Math.Min(GridSize.Width, right);
            bottom = Math.Min(GridSize.Height, bottom);

            var ret = new ArrayGrid<T>(new Size(right - left, bottom - top));

            throw new System.NotImplementedException();
            //foreach (var cell in ret.Points)
            //{
            //    var src = GetFromPoint(cell.Translate(left, top));
            //    ret.Set(cell, src);
            //}

            return ret;
        }

    }
}
