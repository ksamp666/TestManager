using System;
using AppKit;
using Foundation;
using Test_manager.Source.Enums;
using Test_manager.Source.Services;
using Xamarin.Forms;

namespace Test_manager
{
    public partial class MainController : NSViewController
    {
        public static TestRun TestRun { get; private set; }
        
        public MainController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            StartTestButton.Enabled = false;
            HideTestResultsData();
            HideRuntimeApplicationData();
            Forms.Init();
        }

        private void HideTestResultsData() {
            TestFinishedLabel.Hidden = true;
            StatusLabel.Hidden = true;
            StatusValueLabel.Hidden = true;
            DetailsLabel.Hidden = true;
            DetailsTextView.Hidden = true;
        }

        private void HideRuntimeApplicationData() {
            CurrentAngelLabel.Hidden = true;
            CurrentAngelValueLabel.Hidden = true;
            FpsLabel.Hidden = true;
            FpsValueLabel.Hidden = true;
        }

        partial void StartTestButtonClick(NSObject sender) {
            StartTestButton.Enabled = false;
            ShowStatisticsButton.Enabled = false;
            HideTestResultsData();

            TestRun = new TestRun();
            TestRun.Run(PathToRectangleAppField.StringValue, TimeoutField.IntValue);

            CurrentAngelLabel.Hidden = false;
            CurrentAngelValueLabel.Hidden = false;
            FpsLabel.Hidden = false;
            FpsValueLabel.Hidden = false;

            Device.StartTimer(new TimeSpan(0, 0, 1), () => {
                CurrentAngelValueLabel.StringValue = Convert
                    .ToInt32(TestRun.ApplicationData.RotationAngelList.GetLastValue()).ToString();
                FpsValueLabel.StringValue = Convert
                    .ToInt32(1000000 / TestRun.ApplicationData.FrameRenderTimeList.GetLastValue()).ToString();

                if (!TestRun.IsCompleted) return true;

                HideRuntimeApplicationData();
                TestFinishedLabel.Hidden = false;
                StatusLabel.Hidden = false;
                StatusValueLabel.StringValue = TestRun.TestResult.ToString();
                StatusValueLabel.Hidden = false;
                if (TestRun.TestResult == TestResultsEnum.Failed) {
                    DetailsLabel.Hidden = false;
                    DetailsTextView.Value = TestRun.FailData;
                    DetailsTextView.Hidden = false;
                }
                StartTestButton.Enabled = true;
                ShowStatisticsButton.Enabled = true;
                return false;
            });
        }

        partial void SelectRectangleAppPathButtonClick(NSObject sender) {
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = true;
            dlg.CanChooseDirectories = false;
            dlg.AllowedFileTypes = new[] {"public.executable"};

            if (dlg.RunModal() != 1) return;

            var url = dlg.Urls[0];
            PathToRectangleAppField.StringValue = url.Path;
            StartTestButton.Enabled = true;
        }
    }
}