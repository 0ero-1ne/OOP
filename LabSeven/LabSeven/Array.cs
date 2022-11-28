using Newtonsoft.Json;
using System;
using System.IO;

namespace LabSeven
{
    class Array<T> : IArray<T> where T : Circle
    {
        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public int Length { get; private set; }

        private T[] _array = Array.Empty<T>();

        public Array() { }

        public Array(int length, params T[] values)
        {
            Length = length;

            _array = new T[Length];
            for (int i = 0; i < Length; i++)
                _array[i] = values[i];
        }

        public T AddElement(T element)
        {
            Length++;

            T[] _buff = new T[Length];
            for (int i = 0; i < Length - 1; i++)
                _buff[i] = _array[i];

            _buff[Length - 1] = element;
            _array = _buff;

            return element;
        }

        public void RemoveElement(int index)
        {
            T[] _buff = new T[Length - 1];

            for (int i = 0; i < index; i++)
                _buff[i] = _array[i];

            for (int i = index; i < Length - 1; i++)
                _buff[i] = _array[i + 1];

            Length--;

            _array = _buff;
        }

        public T GetElementByPredicate(T predicate) //if no such element - return first element of array
        {
            for (int i = 0; i < Length; i++)
                if (_array[i].Equals(predicate))
                    return _array[i];

            return _array[0];
        }

        public string PrintArray()
        {
            string output = "Array value:\n";
            for (int i = 0; i < Length; i++)
                output += string.Format("Value {0}: ", i) + _array[i].ToString() + "\n";

            return output;
        }

        public void CopyToFile(T element)
        {
            JsonSerializer serializer = new JsonSerializer();
            string output = JsonConvert.SerializeObject(element);
            string filePath = @"D:\OOP\OOP\LabSeven\LabSeven\object.json";

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists) fileInfo.Delete();
            File.AppendAllText(filePath, output);
        }

        public T DeserializeObject() //if filed does not exists or it is empty - return first element of array
        {
            string filePath = @"D:\OOP\OOP\LabSeven\LabSeven\object.json";

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists && fileInfo.Length != 0)
            {
                string json = File.ReadAllText(filePath);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }

            return _array[0];
        }
    }
}
