using System.Collections;
using System.Collections.Generic;

namespace LabNine
{
    partial class Book<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public int Amount
        {
            get => _elements.Count;
        }

        public Dictionary<TKey, TValue> _elements = new Dictionary<TKey, TValue>();

        public Book() { }

        public string GetAllBooks()
        {
            string result = "";

            foreach (var element in _elements)
            {
                result += string.Format("Key - {0}  Title - {1}\n", element.Key, element.Value);
            }

            return result;
        }
    }

    partial class Book<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public bool ContainsKey(TKey key)
        {
            if (_elements.ContainsKey(key))
                return true;

            return false;
        }

        public void Add(TKey key, TValue value)
        {
            _elements.Add(key, value);
        }

        public bool Remove(TKey key)
        {
            if (_elements.ContainsKey(key))
            {
                _elements.Remove(key);
                return true;
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (_elements.TryGetValue(key, out value))
                return true;

            return false;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _elements.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _elements.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            foreach (var element in _elements)
            {
                if (element.Equals(item))
                    return true;
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (_elements.ContainsKey(item.Key))
            {
                _elements.Remove(item.Key);
                return true;
            }

            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public ICollection<TKey> Keys => _elements.Keys;

        public ICollection<TValue> Values => _elements.Values;

        public int Count => _elements.Count;

        public bool IsReadOnly => false;

        public TValue this[TKey key] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
