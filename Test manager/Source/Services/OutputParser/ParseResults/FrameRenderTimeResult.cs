using System;
using Test_manager.Source.Enums;

namespace Test_manager.Source.Services.ParseResults
{
    public class FrameRenderTimeResult : FrameLogResult
    {
        public int RenderTime { get; }

        public FrameRenderTimeResult(int frameNumber, DateTime time, int renderTime) : base(frameNumber, time) {
            RenderTime = renderTime;
        }

        public override ParseResultsEnum GetResultType() {
            return ParseResultsEnum.FrameRenderTime;
        }
    }
}