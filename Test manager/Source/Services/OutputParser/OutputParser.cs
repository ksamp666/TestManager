using System;
using System.Text.RegularExpressions;
using ObjCRuntime;
using Test_manager.Source.Services.ParseResults;

namespace Test_manager.Source.Services
{
    public static class OutputParser
    {
        private static readonly Regex CrashRg = new Regex(@"Application crashed! Error code: \d*");
        private static readonly Regex StackTraceRg = new Regex(@"Line \d*   ");
        private static readonly Regex TimeAndFrameNumberRg = new Regex(@"(\d*): (\d*-\d*-\d* \d*:\d*:\d*.\d*.\d*) \[");

        private static readonly Regex FullTurnRg =
            new Regex(@"Rectangle rotated a full turn\. Completed turns number: (\d*)");

        private static readonly Regex FrameRenderTimeRg =
            new Regex(@"Frame rendered\. Render time: (\d*) microseconds\.");

        private static readonly Regex RotationAngelRg = new Regex(@"Rectangle is rotated\. Current angel: (\d*.\d*)");

        public static IParseResult Parse(string log) {
            if (CrashRg.IsMatch(log) || StackTraceRg.IsMatch(log)) {
                return new CrashDataResult(log);
            }
            if (FullTurnRg.IsMatch(log)) {
                var turnsNumber = int.Parse(FullTurnRg.Matches(log)[0].Groups[1].Value);
                return new TurnsInfoResult(ExtractFrameNumber(log), ExtractTime(log), turnsNumber);
            }
            if (FrameRenderTimeRg.IsMatch(log)) {
                var frameRenderTime = int.Parse(FrameRenderTimeRg.Matches(log)[0].Groups[1].Value);
                return new FrameRenderTimeResult(ExtractFrameNumber(log), ExtractTime(log), frameRenderTime);
            }
            if (RotationAngelRg.IsMatch(log)) {
                var angel = float.Parse(RotationAngelRg.Matches(log)[0].Groups[1].Value);
                return new RotationAngelResult(ExtractFrameNumber(log), ExtractTime(log), angel);
            }
            return new EmptyResult();
        }

        private static int ExtractFrameNumber(string log) {
            if (TimeAndFrameNumberRg.IsMatch(log)) {
                return int.Parse(TimeAndFrameNumberRg.Matches(log)[0].Groups[1].Value);
            }
            throw new RuntimeException("Failed to extract frame number.");
        }

        private static DateTime ExtractTime(string log) {
            if (TimeAndFrameNumberRg.IsMatch(log)) {
                return DateTime.Parse(TimeAndFrameNumberRg.Matches(log)[0].Groups[2].Value);
            }
            throw new RuntimeException("Failed to extract log time.");
        }
    }
}