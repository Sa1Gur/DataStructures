public class DisjointSetUnion
{
    private DisjointSetUnion? parent = null;

    public DisjointSetUnion? Parent
    {
        get => (parent is null) ? this : parent.Parent;
        set => parent = value;
    }

    public int Value { get; set; }

    public int Rank { get; set; }

    public DisjointSetUnion(int value)
    {
        Value = value;
        Rank = 1;
    }
}
