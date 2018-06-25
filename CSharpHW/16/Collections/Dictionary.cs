using System;
using System.Linq;

namespace Collections
{
    class Dictionary<TKey, TValue>
    {
        private TKey[] _keys = new TKey[0];
        private TValue[] _values = new TValue[0];

        public TValue this[TKey key]
        {
            get
            {
                for (var i = 0; i < _keys.Length; i++)
                {
                    if (key.Equals(_keys[i]))
                    {
                        return _values[i];
                    }
                }
                throw new InvalidOperationException();
            }
        }

        public int Length()
        {
            return _keys.Length;
        }

        public void Add(TKey key, TValue value)
        {
            if (_keys.Contains(key)) return;

            var buffKeyArray = new TKey[_keys.Length + 1];
            Array.Copy(_keys, 0, buffKeyArray, 0, _keys.Length);
            _keys = buffKeyArray;
            _keys[_keys.Length - 1] = key;

            var buffValueArray = new TValue[_values.Length + 1];
            Array.Copy(_values, 0, buffValueArray, 0, _values.Length);
            _values = buffValueArray;
            _values[_values.Length - 1] = value;
        }

        public void Remove(TKey key, TValue value)
        {
            if (_keys.Length == 0) return;

            var buffKeyArray = new TKey[_keys.Length - 1];
            var buffValueArray = new TValue[_values.Length - 1];

            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i].Equals(key) && _values[i].Equals(value))
                {
                    i++;
                    Array.Copy(_keys, i, buffKeyArray, i - 1, _keys.Length - i);
                    _keys = buffKeyArray;

                    Array.Copy(_values, i, buffValueArray, i - 1, _values.Length - i);
                    _values = buffValueArray;
                    return;
                }

                buffKeyArray[i] = _keys[i];
                buffValueArray[i] = _values[i];
            }

        }

        public override string ToString()
        {
            var str = string.Empty;
            for (var i = 0; i < _keys.Length; i++)
            {
                str += _keys[i] + " - " + _values[i] + '\n';
            }
            return str;
        }
    }
}