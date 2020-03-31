using System;
using Test_manager.Source.Enums;

namespace Test_manager.Source.Services.ParseResults
{
    public abstract class FrameLogResult: IParseResult
    {
        public DateTime Time { get; }
        public int FrameNumber { get; }

        public FrameLogResult(int frameNumber, DateTime time) {
            FrameNumber = frameNumber;
            Time = time;
        }

        public abstract ParseResultsEnum GetResultType();
    }
}