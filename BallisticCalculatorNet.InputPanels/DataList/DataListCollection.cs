using System.Collections;
using System.Collections.Generic;

namespace BallisticCalculatorNet.InputPanels.DataList
{
    public class DataListCollection<T> : IReadOnlyList<T>
        where T : IDataListItem
    {
        private readonly List<T> mList = new();

        public T this[int index] => mList[index];

        public int Count => mList.Count;

        public IEnumerator<T> GetEnumerator() => mList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => mList.GetEnumerator();

        public void Add(T element) => mList.Add(element);
        
        public void RemoveAt(int index) => mList.RemoveAt(index);

        public void Clear() => mList.Clear();
    }


}
