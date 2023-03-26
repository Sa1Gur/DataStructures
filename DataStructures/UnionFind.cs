public class UnionFind
{
    private int[] _root;
    private int[] _rank;

    public UnionFind(int size)
    {
        if (size <= 0) throw new ArgumentNullException(nameof(size));
        _root = new int[size];
        _rank = new int[size];

        for (int i = 0; i < size; i++)
            (_root[i], _rank[i]) = (i, 1);
    }

    public int Find(int x) => 
    (x == _root[x]) ? x : _root[x] = Find(_root[x]);

    public void Union(int x, int y)
    {
        (int rootX, int rootY) = (Find(x), Find(y));

        if (rootX == rootY) return;
        
        if (_rank[rootX] >= _rank[rootY]) IncorporateSecondInFirst(rootX, rootY);
        else IncorporateSecondInFirst(rootY, rootX);
    }

    private void IncorporateSecondInFirst(int first, int second)
    {
        _root[second] = first;
        _rank[first] += _rank[second];
    }
}
