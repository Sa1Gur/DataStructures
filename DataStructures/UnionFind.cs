public class UnionFind
{
    private int[] root;

    private int[] rank;

    public UnionFind(int size)
    {
        root = new int[size];
        rank = new int[size];

        for (int i = 0; i < size; i++)
        {
            root[i] = i;
            rank[i] = 1;
        }
    }

    public int Find(int x) => 
    (x == root[x]) ? x : root[x] = Find(root[x]);

    public void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX != rootY)
        {
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
}
