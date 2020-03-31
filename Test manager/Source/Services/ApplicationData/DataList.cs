using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_manager.Source.Models
{
    public class DataList<T>
    {
        private readonly T _defaultValue;
        public List<DataNode<T>> ValuesList { get; } = new List<DataNode<T>>();

        public DataList(T defaultValue) {
            _defaultValue = defaultValue;
        }
        
        public void SaveValue(int frameNumber, DateTime dateTime, T value) {
            ValuesList.Add(new DataNode<T>(frameNumber, dateTime, value));
        }
        
        public T GetLastValue() {
            return ValuesList.Count > 0 ? ValuesList.Last().Value : _defaultValue;
        }
    }
}