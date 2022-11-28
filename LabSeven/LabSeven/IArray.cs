namespace LabSeven
{
    interface IArray<T>
    {
        T AddElement(T element);
        void RemoveElement(int index);
        T GetElementByPredicate(T predicate);
    }
}
