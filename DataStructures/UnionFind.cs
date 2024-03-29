namespace DataStructures;

public class UnionFind
{
    private readonly int[] _root;    
    private readonly HashSet<int> _topLevelRoots;
    private readonly int[] _rank;

    public UnionFind(int size)
    {
        if (size <= 0) throw new ArgumentNullException(nameof(size));
        
        _root = Enumerable.Range(0, size).ToArray();
        _topLevelRoots = _root.ToHashSet();
        _rank = Enumerable.Repeat(1, size).ToArray();
    }

    public int Find(int x) => (x == _root[x]) ? x : _root[x] = Find(_root[x]);
    
    public int GetRank(int x) => _rank[Find(x)];
    
    public HashSet<int> GetTopLevelRoots() => new (_topLevelRoots);

    public void Union(int x, int y)
    {
        (int rootX, int rootY) = (Find(x), Find(y));

        if (rootX == rootY) return;
        
        if (_rank[rootX] < _rank[rootY]) (rootX, rootY) = (rootY, rootX);
                                         
        IncorporateSecondInFirst(rootX, rootY);
    }

    private void IncorporateSecondInFirst(int first, int second)
    {
        _root[second] = first;
        _topLevelRoots.Remove(second);
        _rank[first] += _rank[second];        
    }
}