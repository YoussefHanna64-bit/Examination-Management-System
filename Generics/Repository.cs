using System;
using System.Collections.Generic;
using System.Text;

namespace C__Project.Generics
{
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        // private T[] _items;
        // private int _count;
        private List<T> _items;

        public Repository(int initialCapacity = 10)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentException("Capacity must be positive");
            }

            // _items = new T[initialCapacity];
            // _count = 0;
            _items = new List<T>();
        }

        public void Add(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }

            // if (_count >= _items.Length)
            // {
            //     Array.Resize(ref _items, _items.Length * 2);
            // }

            // _items[_count++] = item;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException("Item cannot be null");
            }

            // for (int i = 0; i < _count; i++)
            // {
            //     if (_items[i].Equals(item))
            //     {
            //         for (int j = i; j < _count - 1; j++)
            //         {
            //             _items[j] = _items[j + 1];
            //         }

            //         _items[--_count] = default(T);
            //         return;
            //     }
            // }

            _items.Remove(item);
        }

       public void Sort()
        {
            //Array.Sort(_items, 0, _count);
            _items.Sort();
        }

        public List<T> GetAll()
        {
            // T[] result = new T[_count];
            // Array.Copy(_items, result, _count);
            // return result;
            return new List<T>(_items);
        }
    }
}
