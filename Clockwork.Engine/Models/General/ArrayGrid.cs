﻿using Clockwork.Engine.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Clockwork.Engine.Models.General
{

    public class ArrayGrid<T> : IEnumerable<T>
    {
        private T[] Items;
        public Vector2 Size { get; private set; }
        public int Columns { get { return (int)Size.X; } }
        public int Rows { get { return (int)Size.Y; } }

        public T OutOfBoundsFixedValue;
        public bool ReplaceOutOfBoundsTilesWithAdjacent;

        public ArrayGrid(Vector2 size)
        {
            Size = size;
            Items = new T[(int)size.X * (int)size.Y];
        }

        public ArrayGrid(int columns, IEnumerable<T> items)
        {
            Items = items.ToArray();
            if (columns == 0)
                Size = Vector2.Zero;
            else
                Size = new Vector2(columns, Items.Length / columns);
        }

        public ArrayGrid<K> Map<K>(Func<T, K> mapping)
        {
            return new ArrayGrid<K>(Columns, Items.Select(mapping));
        }

        public void Set(Vector2 point, T value)
        {
            Set(PointToIndex(point, 0), value);
        }

        public void Set(int index, T value)
        {
            Items[index] = value;
        }

        public Vector2 IndexToPoint(int index)
        {
            return index.ToXY(Columns);
        }

        public int PointToIndex(Vector2 point, int outOfBoundsReturn)
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
            foreach (var point in block.GetPoints(new Vector2(1, 1)))
            {
                Set(point, value);
            }
        }

        public T GetFromPoint(Vector2 p)
        {
            var index = PointToIndex(p, -1);
            if (index == -1)
            {
                if (ReplaceOutOfBoundsTilesWithAdjacent)
                {
                    Vector2 adjusted = new Vector2(p.X.KeepInsideRange(0, Size.X - 1), p.Y.KeepInsideRange(0, Size.Y - 1));
                    return GetFromPoint(adjusted);
                }
                else
                    return OutOfBoundsFixedValue;
            }
            else
                return Items[index];
        }

        public T GetFromPointOrDefault(Vector2 p)
        {
            var index = PointToIndex(p, -1);
            if (index == -1)
                return default(T);
            else
                return Items[index];
        }

        public IEnumerable<ArrayGridPoint<T>> PointItems
        {
            get
            {
                return Points.Select(p => new ArrayGridPoint<T>(p, this));
            }
        }

        public IEnumerable<Vector2> Points
        {
            get
            {
                for (int y = 0; y < Rows; y++)
                {
                    for (int x = 0; x < Columns; x++)
                    {
                        yield return new Vector2(x, y);
                    }
                }
            }
        }

        public IEnumerable<ArrayGridPoint<T>> GetPointsInLine(Vector2 start, Direction dir)
        {
            Vector2 point = start;

            while (PointToIndex(point, -1) != -1)
            {
                yield return new ArrayGridPoint<T>(point, this);
                point = point.GetAdjacent(dir);
            }

            yield return new ArrayGridPoint<T>(point, this);
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
            right = Math.Min((int)Size.X, right);
            bottom = Math.Min((int)Size.Y, bottom);

            var ret = new ArrayGrid<T>(new Vector2(right - left, bottom - top));

            foreach (var cell in ret.Points)
            {
                var src = GetFromPoint(cell.Translate(left, top));
                ret.Set(cell, src);
            }

            return ret;
        }

    }
}
