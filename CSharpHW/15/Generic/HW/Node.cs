using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Node<T>
    {
        private Node<T> _previous;
        private Node<T> _next;
        private T _value;

        public Node(T value)
        {
            _value = value;
        }

        public Node<T> Next { get => _next; set => _next = value; }
        public Node<T> Previous { get => _previous; set => _previous = value; }
        public T Value { get => _value; set => _value = value; }
    }
}
