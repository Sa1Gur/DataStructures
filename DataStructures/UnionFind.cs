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
        
        if (_rank[rootX] >= _rank[rootY])
        {
            _root[rootY] = _rootX;
            _rank[rootX] += _rank[rootY];
        }
        else
        {
            _root[rootX] = _rootY;
            _rank[rootY] += _rank[rootX];
        }
    }
}
