using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Test_manager.Source.Enums;
using Test_manager.Source.Models;
using Test_manager.Source.Services.ParseResults;

namespace Test_manager.Source.Services
{
    public class TestRun
    {
        private readonly StringBuilder _applicationLog = new StringBuilder();
        private readonly StringBuilder _crashLog = new StringBuilder();
        public TestResultsEnum TestResult { get; private set; }
        public string FailData { get; private set; } = "";
        public bool IsCompleted { get; private set; }
        public ApplicationData ApplicationData { get; } = new ApplicationData();

        public void Run(string pathToExecutable, int timeout) {
            IsCompleted = false;

            var process = new Process {
                StartInfo = {
                    FileName = pathToExecutable,
                    Arguments = timeout.ToString(),
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                },
                EnableRaisingEvents = true
            };
            process.Start();
            process.OutputDataReceived += OnOutputDataReceived;
            process.BeginOutputReadLine();
            process.ErrorDataReceived += OnOutputDataReceived;
            process.BeginErrorReadLine();
            process.Exited += OnExit;
        }

        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e) {
            var msg = e.Data;

            if (IsCompleted || msg == null) return;

            //Updated application data
            var parseResult = OutputParser.Parse(msg);
            if (parseResult.GetResultType() == ParseResultsEnum.TurnsInfo) {
                var result = (TurnsInfoResult) parseResult;
                ApplicationData.TurnsNumberList.SaveValue(result.FrameNumber, result.Time, result.TurnsNumber);
            }
            if (parseResult.GetResultType() == ParseResultsEnum.CurrentAngel) {
                var result = (RotationAngelResult) parseResult;
                ApplicationData.RotationAngelList.SaveValue(result.FrameNumber, result.Time, result.Angel);

                if (ApplicationData.RotationAngelList.ValuesList.Count > 2) {
                    var previousRotationAngelData = ApplicationData.RotationAngelList
                        .ValuesList[ApplicationData.RotationAngelList.ValuesList.Count - 2];
                    var angelDifference = previousRotationAngelData.Value > result.Angel
                        ? ApplicationData.RotationAngelList.GetLastValue() + 360 - previousRotationAngelData.Value
                        : ApplicationData.RotationAngelList.GetLastValue() - previousRotationAngelData.Value;
                    var timePeriodInSeconds = (result.Time - previousRotationAngelData.DateTime).TotalSeconds;
                    var angularVelocity = angelDifference / timePeriodInSeconds;
                    ApplicationData.AngularVelocityList.SaveValue(result.FrameNumber, result.Time, angularVelocity);
                }
            }
            if (parseResult.GetResultType() == ParseResultsEnum.FrameRenderTime) {
                var result = (FrameRenderTimeResult) parseResult;
                ApplicationData.FrameRenderTimeList.SaveValue(result.FrameNumber, result.Time, result.RenderTime);
            }
            
            //Save log
            if (parseResult.GetResultType() == ParseResultsEnum.CrashData) {
                _crashLog.AppendLine(((CrashDataResult) parseResult).CrashData);
            } else {
                _applicationLog.AppendLine(msg);
            }
        }

        private void OnExit(object sender, EventArgs args) {
            IsCompleted = true;
            CollectTestResults((Process) sender);
            var angularVelocityList = ApplicationData.AngularVelocityList.ValuesList;
            TestRunsDataStorage.AddTestRunData(new TestRunStoreDataModel {
                TurnsNumber = ApplicationData.TurnsNumberList.GetLastValue(),
                VelocityAverage = angularVelocityList.Select(val => val.Value).Average(),
                VelocityMedian = angularVelocityList.Select(val => val.Value)
                    .OrderBy(value => value).ToList()[angularVelocityList.Count / 2],
                VelocityStandardDeviation =
                    Utils.CalculateStandardDeviation(angularVelocityList.Select(val => val.Value))
            });
        }

        private void CollectTestResults(Process process) {
            switch (process.ExitCode) {
                case 0:
                    TestResult = TestResultsEnum.Passed;
                    break;
                default:
                    TestResult = TestResultsEnum.Failed;
                    var builder = new StringBuilder();
                    builder.AppendLine("Exit code: " + process.ExitCode);
                    builder.AppendLine("Start time: " + process.StartTime.ToString("u"));
                    builder.AppendLine("End time: " + process.ExitTime.ToString("u"));
                    builder.AppendLine("");
                    builder.AppendLine("Crash log:");
                    builder.Append(_crashLog.ToString());
                    builder.AppendLine("");
                    builder.AppendLine("Application log:");
                    builder.Append(_applicationLog.ToString());
                    FailData = builder.ToString();
                    break;
            }
        }
    }
}