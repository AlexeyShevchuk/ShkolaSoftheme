using System;

namespace Collections
{
    class Stack<T>
    {
        private T[] _array;

        public Stack()
        {
            _array = new T[0];
        }

        public bool IsEmpty()
        {
            return _array.Length == 0;
        }

        public T Pop()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException();
            }
            var buffArray = new T[_array.Length - 1];
            var pop = _array[_array.Length - 1];
            Array.Copy(_array, 0, buffArray, 0, _array.Length - 1);
            _array = buffArray;
            return pop;
        }

        public void Push(T item)
        {
            var buffArray = new T[_array.Length + 1];
            Array.Copy(_array, 0, buffArray, 0, _array.Length);
            _array = buffArray;
            _array[_array.Length-1] = item;
        }

        public T Peek()
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return _array[_array.Length - 1];
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
