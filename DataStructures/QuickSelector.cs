public class QuickSelector
{
    public int FindKthLargest(int[] nums, int k) => QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
    
    private int QuickSelect(int[] nums, int left, int right, int k)
    {
        if (left == right) return nums[left];
        
        int pIndex = new Random().Next(left, right + 1);
        
        pIndex = Partition(nums, left, right, pIndex);
        return (pIndex - k) switch
        {
            0 => nums[k],
            < 0 => QuickSelect(nums, pIndex + 1, right, k),
            > 0 => QuickSelect(nums, left, pIndex - 1, k)
        };
    }
    private int Partition(int[] nums, int left, int right, int pIndex)
    {
        int pivot = nums[pIndex];
        Swap(nums, pIndex, right);
        
        pIndex = left;
        
        for (int i = left; i <= right; i++)
        {
            if (nums[i] <= pivot)
            {
                Swap(nums, i, pIndex++);
            }
        }
        
        return pIndex - 1;
    }
    private void Swap(int[] nums, int x, int y) => (nums[x], nums[y]) = (nums[y], nums[x]);
}
