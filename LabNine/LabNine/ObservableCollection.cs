using System.Collections.Generic;

namespace LabNine
{
    class ObservableCollection<T>
    {
        public event CollectionChange CollectionChanged;
        List<T> collection = new List<T>();

        public ObservableCollection() { }

        public void Add(T obj)
        {
            collection.Add(obj);
            CollectionChanged();
        }

        public void Remove(T obj)
        {
            collection.Remove(obj);
            CollectionChanged();
        }
    }
}
