using System.Collections;

namespace DataStructures
{
    public class BiDictionary<TFirst, TSecond> : IEnumerable
    {
        readonly IDictionary<TFirst, IList<TSecond>> _firstToSecond = new Dictionary<TFirst, IList<TSecond>>();
        readonly IDictionary<TSecond, IList<TFirst>> _secondToFirst = new Dictionary<TSecond, IList<TFirst>>();

        static readonly IList<TFirst> _emptyFirstList = Array.Empty<TFirst>();
        static readonly IList<TSecond> _emptySecondList = Array.Empty<TSecond>();

        public void Add(TFirst first, TSecond second)
        {
            if (!_firstToSecond.TryGetValue(first, out IList<TSecond> seconds))
            {
                seconds = new List<TSecond>();
                _firstToSecond[first] = seconds;
            }

            if (!_secondToFirst.TryGetValue(second, out IList<TFirst> firsts))
            {
                firsts = new List<TFirst>();
                _secondToFirst[second] = firsts;
            }

            seconds.Add(second);
            firsts.Add(first);
        }

        public IList<TSecond> this[TFirst first] => GetByFirst(first);

        public IList<TFirst> this[TSecond second] => GetBySecond(second);

        public IList<TSecond> GetByFirst(TFirst first)
        {
            IList<TSecond> list;
            if (!_firstToSecond.TryGetValue(first, out list))
            {
                return _emptySecondList;
            }

            return new List<TSecond>(list);
        }

        public IList<TFirst> GetBySecond(TSecond second)
        {
            IList<TFirst> list;
            if (!_secondToFirst.TryGetValue(second, out list))
            {
                return _emptyFirstList;
            }

            return new List<TFirst>(list);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator GetEnumerator() => _firstToSecond.GetEnumerator();
    }
}