namespace Practice.StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    internal class MaxStack<T> where  T: struct,IComparable<T>
    {

        Stack<T> _items;
        Stack<KeyValuePair<int, T>> _max;

        public MaxStack()
        {
            _items = new Stack<T>();
            _max = new Stack<KeyValuePair<int, T>>();
        }

        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public void Push(T item)
        {
            _items.Push(item);
            if ((_max.Count == 0) || (_max.Peek().Value.CompareTo(item) < 0))
            {
                _max.Push(new KeyValuePair<int, T>(_items.Count, item));
            }
        }

        public T Pop()
        {
            if ((_max.Count > 0) && (_max.Peek().Key == _items.Count))
            {
                _max.Pop();
            }

            return _items.Pop();
        }

        public T Max
        {
            get
            {
                if (_max.Count == 0) throw new InvalidOperationException("Stack is empty");
                return _max.Peek().Value;
            }
        }
    }
}
