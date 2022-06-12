/*
RandomizedCollection is a data structure that contains a collection of numbers, possibly duplicates (i.e., a multiset). It should support inserting and removing specific elements and also removing a random element.

Implement the RandomizedCollection class:

RandomizedCollection() Initializes the empty RandomizedCollection object.
bool insert(int val) Inserts an item val into the multiset, even if the item is already present. Returns true if the item is not present, false otherwise.
bool remove(int val) Removes an item val from the multiset if present. Returns true if the item is present, false otherwise. Note that if val has multiple occurrences in the multiset, we only remove one of them.
int getRandom() Returns a random element from the current multiset of elements. The probability of each element being returned is linearly related to the number of same values the multiset contains.
Each function works on average O(1) time complexity.
*/
public class RandomizedCollection

{

    private Dictionary<int, HashSet<int>> _direct = new ();

    private Dictionary<int, int> _reverse = new ();

    private int _biggestIndex = 0;

    private Random _rnd = new ();

    

    public bool Insert(int val)

    {

        if (!_direct.ContainsKey(val)) _direct.Add(val, new());

        _direct[val].Add(_biggestIndex);

        _reverse.Add(_biggestIndex, val);

        _biggestIndex++;

        

        return _direct[val].Count == 1;

    }

    

    public bool Remove(int val)

    {

        if (!_direct.ContainsKey(val)) return false;

        

        _biggestIndex--;

        

        int deletedIndex = _direct[val].Last();

        

        if (_reverse[deletedIndex] == _reverse[_biggestIndex])

        {

            deletedIndex = _biggestIndex;

        }

        else

        {

            int valAtBiggestIndex = _reverse[_biggestIndex];

            _reverse[deletedIndex] = valAtBiggestIndex;

            _direct[valAtBiggestIndex].Remove(_biggestIndex);

            _direct[valAtBiggestIndex].Add(deletedIndex);

        }

        

        _reverse.Remove(_biggestIndex);

        _direct[val].Remove(deletedIndex);

        

        if (_direct[val].Count == 0) _direct.Remove(val);

            

        return true;

    }

    

    public int GetRandom() => _biggestIndex > 0 ? _reverse[_rnd.Next(0, _biggestIndex)] : throw new ArgumentException("Collection is empty");

}
