public class DisjointSetUnion
{
    private DisjointSetUnion? _parent = null;

    public DisjointSetUnion? Parent
    {
        get => (_parent is null) ? this : _parent.Parent;
        set
        {
            if (_parent is null) _parent = value;
            else _parent.Parent = value;
        }
    }

    public int Value { get; set; }

    public int Rank { get; set; }

    public DisjointSetUnion(int value)
    {
        Value = value;
        Rank = 1;
    }
}
