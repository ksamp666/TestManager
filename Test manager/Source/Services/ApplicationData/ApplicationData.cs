using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_manager.Source.Models
{
    public class ApplicationData
    {
        public DataList<int> TurnsNumberList { get; } = new DataList<int>(0);
        public DataList<int> FrameRenderTimeList { get; } = new DataList<int>(1);
        public DataList<double> RotationAngelList { get; } = new DataList<double>(0);
        public DataList<double> AngularVelocityList { get; } = new DataList<double>(0);
    }
}