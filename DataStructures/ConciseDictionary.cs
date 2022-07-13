//because it's a pain to use C# Dictionary syntax
public class ConciseDictionary<T, U> : Dictionary<T, U>
{
    private U _missing;

    public ConciseDictionary(U missing) => _missing = missing;

    public U this[T i]
    {
        get => this.ContainsKey(i) ? ((Dictionary<T, U>)this)[i] : _missing;
        set
        {
            if (this.ContainsKey(i)) ((Dictionary<T, U>)this)[i] = value;
            else this.Add(i, value);
        }
    }
}
