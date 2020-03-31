// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Test_manager
{
	[Register ("MainController")]
	partial class MainController
	{
		[Outlet]
		AppKit.NSTextField CurrentAngelLabel { get; set; }

		[Outlet]
		AppKit.NSTextField CurrentAngelValueLabel { get; set; }

		[Outlet]
		AppKit.NSTextField DetailsLabel { get; set; }

		[Outlet]
		AppKit.NSTextView DetailsTextView { get; set; }

		[Outlet]
		AppKit.NSTextField FpsLabel { get; set; }

		[Outlet]
		AppKit.NSTextField FpsValueLabel { get; set; }

		[Outlet]
		AppKit.NSTextField PathToRectangleAppField { get; set; }

		[Outlet]
		AppKit.NSButton ShowStatisticsButton { get; set; }

		[Outlet]
		AppKit.NSButton StartTestButton { get; set; }

		[Outlet]
		AppKit.NSTextField StatusLabel { get; set; }

		[Outlet]
		AppKit.NSTextField StatusValueLabel { get; set; }

		[Outlet]
		AppKit.NSTextField TestFinishedLabel { get; set; }

		[Outlet]
		AppKit.NSTextField TimeoutField { get; set; }

		
		[Action ("StartTestButtonClick:")]
		partial void StartTestButtonClick (Foundation.NSObject sender);
		
		[Action ("SelectRectangleAppPathButtonClick:")]
		partial void SelectRectangleAppPathButtonClick (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (PathToRectangleAppField != null) {
				PathToRectangleAppField.Dispose ();
				PathToRectangleAppField = null;
			}

			if (TimeoutField != null) {
				TimeoutField.Dispose ();
				TimeoutField = null;
			}

			if (TestFinishedLabel != null) {
				TestFinishedLabel.Dispose ();
				TestFinishedLabel = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}

			if (StatusValueLabel != null) {
				StatusValueLabel.Dispose ();
				StatusValueLabel = null;
			}

			if (DetailsLabel != null) {
				DetailsLabel.Dispose ();
				DetailsLabel = null;
			}

			if (CurrentAngelLabel != null) {
				CurrentAngelLabel.Dispose ();
				CurrentAngelLabel = null;
			}

			if (CurrentAngelValueLabel != null) {
				CurrentAngelValueLabel.Dispose ();
				CurrentAngelValueLabel = null;
			}

			if (FpsLabel != null) {
				FpsLabel.Dispose ();
				FpsLabel = null;
			}

			if (FpsValueLabel != null) {
				FpsValueLabel.Dispose ();
				FpsValueLabel = null;
			}

			if (ShowStatisticsButton != null) {
				ShowStatisticsButton.Dispose ();
				ShowStatisticsButton = null;
			}

			if (StartTestButton != null) {
				StartTestButton.Dispose ();
				StartTestButton = null;
			}

			if (DetailsTextView != null) {
				DetailsTextView.Dispose ();
				DetailsTextView = null;
			}
		}
	}
}
