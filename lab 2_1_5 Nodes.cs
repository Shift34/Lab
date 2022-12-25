using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassLibrary4
{
    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Value = data;
            Next = null;
        }
    }

    public class MyList<T> : IEnumerable<T>
    {
        private Node<T> _head, _tail, _previous;
        public int Count { get; private set; }

        public MyList()
        {
            _head = null;
            Count = 0;
        }

        public MyList(IEnumerable<T> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException();
            }

            if (!values.Any())
            {
                Count = 0;
            }

            foreach (var value in values)
            {
                Add(value);
            }

        }
        public void AddAfterValue(T value, T value1)
        {
            for (var node = _head; node != null; node = node.Next)
            {
                Node<T> newNode = new Node<T>(value1);
                _previous = node.Next;
                if (node.Value.Equals(value))
                {
                    node.Next = newNode;
                    node = newNode;
                    node.Next = _previous;
                    Count++;
                }
                _previous = node;
            }
            _tail = _previous;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                _tail.Next = newNode;
            }
            _tail = newNode;
            Count++;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var node = _head; node != null; node = node.Next)
            {
                yield return node.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var node = _head; node != null; node = node.Next)
            {
                yield return node.Value;
            }
        }
    }
}
