using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW
{
    class List<T>
    {
        int _count;
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public List()
        {
            Head = null;
            Tail = null;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;

            _count++;
        }

        public bool Remove(T data)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    Tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }

                _count--;

                return true;
            }
            return false;
        }

        public int GetLength()
        {
            return _count;
        }

        public bool Contains(T value)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            var current = Head;
            var array = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }
    }
}
