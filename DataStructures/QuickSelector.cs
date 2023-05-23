public class QuickSelector
{
    private Random _randomGenerator = new ();
    public int FindKthLargest(int[] nums, int k) => QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
    
    private int QuickSelect(int[] nums, int left, int right, int k)
    {
        if (left == right) return nums[left];
        
        int pIndex = PartitionByLomuto(nums, left, right, _randomGenerator.Next(left, right + 1));
        return (pIndex - k) switch
        {
            0 => nums[k],
            < 0 => QuickSelect(nums, pIndex + 1, right, k),
            > 0 => QuickSelect(nums, left, pIndex - 1, k)
        };
    }

    private int PartitionByLomuto(int[] nums, int left, int right, int pIndex)
    {
        int pivot = nums[pIndex];
        Swap(nums, pIndex, right);
        
        pIndex = left;
        
        for (int i = left; i <= right; i++)
        {
            if (nums[i] > pivot) continue;
            
            Swap(nums, i, pIndex++);
        }
        
        return pIndex - 1;
    }

    private void Swap(int[] nums, int x, int y) => (nums[x], nums[y]) = (nums[y], nums[x]);
}
