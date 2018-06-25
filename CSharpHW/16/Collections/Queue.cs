using System;

namespace Collections
{
    class Queue<T>
    {
        private T[] _array;

        public Queue()
        {
            _array = new T[0];
        }

        public int Count()
        {
            return _array.Length;
        }

        public bool IsEmpty()
        {
            return _array.Length == 0;
        }

        public void Enqueue(T item)
        {
            var buffArray = new T[_array.Length + 1];
            Array.Copy(_array, 0, buffArray, 0, _array.Length);
            _array = buffArray;
            _array[_array.Length-1] = item;
        }

        public T Dequeue()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException();
            }
            var buffArray = new T[_array.Length - 1];
            Array.Copy(_array, 1, buffArray, 0, _array.Length - 1);
            var dequeue = _array[0];
            _array = buffArray;
            return dequeue;
        }

        public T Peek()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return _array[0];
        }

        public override string ToString()
        {
            var str = string.Empty;
            foreach (var s in _array)
            {
                str += s + "\n";
            }
            return str;
        }
    }
}

