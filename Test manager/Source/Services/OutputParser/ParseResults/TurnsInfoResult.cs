using System;
using Test_manager.Source.Enums;

namespace Test_manager.Source.Services.ParseResults
{
    public class TurnsInfoResult : FrameLogResult
    {
        public int TurnsNumber { get; }

        public TurnsInfoResult(int frameNumber, DateTime time, int turnsNumber) : base(frameNumber, time) {
            TurnsNumber = turnsNumber;
        }

        public override ParseResultsEnum GetResultType() {
            return ParseResultsEnum.TurnsInfo;
        }
    }
}