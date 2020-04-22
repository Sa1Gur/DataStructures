using System;

namespace DataStructures
{
    public class Heap<T>
    {
        int _capacity = 16;
        int _size = 0;

        T[] _items;
        Func<T, T, bool> _comparer;

        public Heap(Func<T, T, bool> comparer)
        {
            _items = new T[_capacity];
            _comparer = comparer;
        }

        int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;
        bool HasRightChild(int index) => GetRightChildIndex(index) < _size;
        bool HasParent(int index) => GetParentIndex(index) >= 0;

        T LeftChild(int index) => _items[GetLeftChildIndex(index)];
        T RightChild(int index) => _items[GetRightChildIndex(index)];
        T Parent(int index) => _items[GetParentIndex(index)];

        void Swap(int indexOne, int indexTwo)
        {
            T temp = _items[indexOne];
            _items[indexOne] = _items[indexTwo];
            _items[indexTwo] = temp;
        }

        void EnsureExtraCapacity()
        {
            if (_size == _capacity)
            {
                if (int.MaxValue / 2 < _capacity) throw new IndexOutOfRangeException($"capacity cannot exceed {int.MaxValue}");
                _capacity *= 2;
                Array.Resize(ref _items, _capacity);                
            }
        }

        public bool Any() => _size != 0;

        public T Peek()
        {
            if (!Any()) throw new NotSupportedException($"heap is empty");

            return _items[0];
        }

        public T Pop()
        {
            if (!Any()) throw new NotSupportedException($"heap is empty");

            var item = _items[0];
            _size--;
            _items[0] = _items[_size];            
            HeapifyDown();
            return item;
        }

        public void Push(T item)
        {
            EnsureExtraCapacity();

            _items[_size++] = item;
            HeapifyUp();
        }

        void HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && _comparer(Parent(index), _items[index]))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = SmallerChildIndex(index);

                if (!_comparer(_items[smallerChildIndex], _items[index]))
                {
                    Swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private int SmallerChildIndex(int index)
        {
            int smallerChildIndex = GetLeftChildIndex(index);
            if (HasRightChild(index) && _comparer(RightChild(index), LeftChild(index)))
            {
                smallerChildIndex = GetRightChildIndex(index);
            }

            return smallerChildIndex;
        }
    }
}