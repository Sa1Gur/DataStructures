using System;
using System.Linq;

using Xunit;

public class QuickSelectorTests
{
    [Theory]
    [InlineData(1)]
    public void PropertyTest(int k)
    {
        int [] tst = new int[] {1, 11, 23, 3, 111};
        int value = new QuickSelector().FindKthLargest(tst,k);
        Assert.Equal(value, tst.OrderByDescending(x => x).Skip(k - 1).First());
    }
}
