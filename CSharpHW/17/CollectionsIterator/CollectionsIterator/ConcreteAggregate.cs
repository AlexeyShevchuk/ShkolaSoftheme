using System.Collections;

namespace CollectionsIterator
{
    class ConcreteAggregate<T> : Aggregate<T>
    {
        private T[] _items = new T[0];

        public override Iterator<T> CreateIterator()
        {
            return new ConcreteIterator<T>(this);
        }

        public int Count
        {
            get { return _items.Length; }
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { Insert(index, value); }
        }

        public bool Insert(int index, T value)
        {
            if (index >= _items.Length + 1)
            {
                return false;
            }
            var itemsBuff = new T[_items.Length + 1];
            for (int i = 0, j = 0; i < itemsBuff.Length; i++,j++)
            {
                if (i == index)
                {
                    itemsBuff[index] = value;
                    j++;
                    continue;
                }
                itemsBuff[j] = _items[i];
            }
            _items = itemsBuff;
            return true;
        }
    }
}