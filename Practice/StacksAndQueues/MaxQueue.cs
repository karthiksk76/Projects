namespace Practice.StacksAndQueues
{
    using System;
    using System.Collections.Generic;

    internal class MaxQueue<T> where T : struct, IComparable<T>
    {

        MaxStack<T> _s1;
        MaxStack<T> _s2;

        public MaxQueue()
        {
            _s1 = new MaxStack<T>();
            _s2 = new MaxStack<T>();
        }

        public int Count
        {
            get
            {
                return (_s1.Count + _s2.Count);
            }
        }

        public void Enqueue(T item)
        {
            _s1.Push(item);
        }

        public T Dequeue()
        {
            if (_s2.Count == 0)
            {
                while (_s1.Count > 0)
                {
                    _s2.Push(_s1.Pop());
                }
            }

            if (_s2.Count == 0) throw new InvalidOperationException("Queue is empty");

            return _s2.Pop();
        }

        public T Max
        {
            get
            {
                if (Count == 0) throw new InvalidOperationException("Stack is empty");
                if (_s1.Count == 0) return _s2.Max;
                else if (_s2.Count == 0) return _s1.Max;
                else
                {
                    return _s1.Max.CompareTo(_s2.Max) > 0 ? _s1.Max : _s2.Max;
                }
            }
        }
    }
}
