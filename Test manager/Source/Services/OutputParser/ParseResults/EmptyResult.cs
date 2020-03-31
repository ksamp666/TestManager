using Test_manager.Source.Enums;

namespace Test_manager.Source.Services.ParseResults
{
    public class EmptyResult: IParseResult
    {
        public ParseResultsEnum GetResultType() {
            return ParseResultsEnum.Empty;
        }
    }
}