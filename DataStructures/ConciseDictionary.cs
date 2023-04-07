//because it's a pain to use C# Dictionary syntax
namespace DataStructures;

public class ConciseDictionary<T, U> : Dictionary<T, U>
{
    private readonly U _missing;

    public ConciseDictionary(U missing) => _missing = missing;

    public new U this[T i]
    {
        get => ContainsKey(i) ? ((Dictionary<T, U>)this)[i] : _missing;
        set
        {
            if (ContainsKey(i)) ((Dictionary<T, U>)this)[i] = value;
            else Add(i, value);
        }
    }
}