using System;
using Test_manager.Source.Enums;

namespace Test_manager.Source.Services.ParseResults
{
    public class RotationAngelResult : FrameLogResult
    {
        public float Angel { get; }
        
        public RotationAngelResult(int frameNumber, DateTime time, float angel) : base(frameNumber, time) {
            Angel = angel;
        }
        
        public override ParseResultsEnum GetResultType() {
            return ParseResultsEnum.CurrentAngel;
        }
    }
}