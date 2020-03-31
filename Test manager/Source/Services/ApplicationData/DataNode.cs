using System;

namespace Test_manager.Source.Models
{
    public class DataNode<T>
    {
        public int FrameNumber { get; }
        public DateTime DateTime { get; }
        public T Value { get; }

        public DataNode(int frameNumber, DateTime dateTime, T value) {
            FrameNumber = frameNumber;
            DateTime = dateTime;
            Value = value;
        }
    }
}