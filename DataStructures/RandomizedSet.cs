/*
RandomizedSet class:

RandomizedSet() Initializes the RandomizedSet object.

bool insert(int val) Inserts an item val into the set if not present. Returns true if the item was not present, false otherwise.

bool remove(int val) Removes an item val from the set if present. Returns true if the item was present, false otherwise.

int getRandom() Returns a random element from the current set of elements (it's guaranteed that at least one element exists when this method is called). Each element must have the same probability of being returned.

Each function works in average O(1) time complexity.
*/
public class RandomizedSet

{

    private Dictionary<int, int> _direct = new ();

    private Dictionary<int, int> _reverse = new ();

    private int _biggestIndex = 0;

    private Random _rnd = new ();

    public bool Insert(int val)

    {

        if (!_direct.ContainsKey(val))

        {

            _direct.Add(val, _biggestIndex);

            _reverse.Add(_biggestIndex, val);

            _biggestIndex++;

            return true;

        }

        return false;

    }

    public bool Remove(int val)

    {

        if (!_direct.ContainsKey(val)) return false;

        _biggestIndex--;

        int deletedIndex = _direct[val];

        if (deletedIndex != _biggestIndex)

        {

            int valAtBiggestIndex = _reverse[_biggestIndex];

            _reverse[deletedIndex] = valAtBiggestIndex;

            _direct[valAtBiggestIndex] = deletedIndex;

        }

        _reverse.Remove(_biggestIndex);

        _direct.Remove(val);

        return true;

    }

    public int GetRandom() => _biggestIndex > 0 ? _reverse[_rnd.Next(0, _biggestIndex)] : throw new ArgumentException("Set is empty");

}
