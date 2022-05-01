using System;

namespace DataStructures;

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

    void Swap(int indexOne, int indexTwo) => (_items[indexOne], _items[indexTwo]) = (_items[indexTwo], _items[indexOne]);

    void EnsureExtraCapacity()
    {
         if (_size != _capacity) return;
         
         if (int.MaxValue / 2 < _capacity) throw new IndexOutOfRangeException($"capacity cannot exceed {int.MaxValue}");
         _capacity *= 2;
         Array.Resize(ref _items, _capacity);         
    }

    public bool Any() => _size != 0;

    public T Peek() => !Any() ? throw new NotSupportedException($"heap is empty") : _items[0];

    public T Pop()
    {
        if (!Any()) throw new NotSupportedException($"heap is empty");

        var item = _items[0];
        _items[0] = _items[--_size];
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
            int closerChildIndex = CloserChildIndex(index);

            if (_comparer(_items[closerChildIndex], _items[index])) break;
            
            Swap(index, closerChildIndex);
            index = closerChildIndex;
        }
    }

    int CloserChildIndex(int index)
    {
        int closerChildIndex = GetLeftChildIndex(index);
        if (HasRightChild(index) && _comparer(LeftChild(index), RightChild(index)))
        {
            closerChildIndex = GetRightChildIndex(index);
        }

        return closerChildIndex;
    }
}
