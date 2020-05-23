using DataStructures;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class HeapTests
    {      
        [Fact]
        public void TestMinHeap()
        {
            var heap = new Heap<int>((x, y) => x > y);
            
            heap.Push(30301275);
            heap.Push(19973434);
            heap.Push(63004643);
            heap.Push(54007648);
            
            heap.Pop();
            Assert.Equal(30301275, heap.Peek());
        }
    }
}
