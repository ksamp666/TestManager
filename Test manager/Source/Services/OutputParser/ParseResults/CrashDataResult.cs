using System;
using Test_manager.Source.Enums;

namespace Test_manager.Source.Services.ParseResults
{
    public class CrashDataResult: IParseResult
    {
        public string CrashData { get; }

        public CrashDataResult(string crashData) {
            CrashData = crashData;
        }

        public ParseResultsEnum GetResultType() {
            return ParseResultsEnum.CrashData;
        }
    }
}