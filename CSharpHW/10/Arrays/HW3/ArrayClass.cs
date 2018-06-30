using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class ArrayClass
    {
        public int[] Arr { get; private set; }

        public ArrayClass()
        {
            Arr = new int[0];
        }

        public ArrayClass(int[] array)
        {
            Arr = array ?? throw new NullReferenceException();
        }

        public void Add(int value)
        {
            var newArray = new int[Arr.Length + 1];
            Arr.CopyTo(newArray, 0);
            newArray[newArray.Length - 1] = value;
            Arr = newArray;
        }

        public bool Contains(int value)
        {
            if (Arr.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetByIndex(int index)
        {
            if (index >= Arr.Length && index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return Arr[index];
        }
    }
}
