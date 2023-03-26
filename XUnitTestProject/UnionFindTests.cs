using DataStructures; 
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit; 

namespace XUnitTestProject; 

public class UnionFindTests 
{       
    [Fact]
    public void TestMinHeap()
    {
        int n = 4;
        
        UnionFind uf = new(n);
        
        uf.Union(0, 1);
        uf.Union(0, 2);
        
        Dictionary<int, List<int>> result = new ();
        
        for(int i = 0; i < n; i++)
        {
            int rootI = uf.Find(i);
            
            if (!result.ContainsKey(rootI)) result.Add(rootI, new ());
            
            result[rootI].Add(i);
        }

        Assert.Equal(result.Count, 2);
        Assert.Equal(result[0], 3);
    }
}
