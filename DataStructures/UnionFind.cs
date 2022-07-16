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
        
        if (rank[rootX] >= rank[rootY])
        {
            root[rootY] = rootX;
            rank[rootX] += rank[rootY];
        }
        else
        {
            root[rootX] = rootY;
            rank[rootY] += rank[rootX];
        }
    }
}
