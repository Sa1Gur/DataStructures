using System;

namespace DataStructures;

public class FenwickTree
{
    private int[] tree;
    
    public FenwickTree(int size) => tree = new int[size + 1];
    
    public void Update(int index, int value)
    {
        for (++index; index < tree.Length; index += index & -index)
        {
            tree[index] += value;
        }
    }
    
    public int Query(int left, int right) =>  PrefixSum(right) - (left > 0 ? PrefixSum(left - 1) : 0);
    private int PrefixSum(int index)
    {
        int sum = 0;
        for (++index; index > 0; index -= index & -index) sum += tree[index];
        
        return sum;
    }
}
