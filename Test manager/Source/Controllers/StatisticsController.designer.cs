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
	[Register ("StatisticsController")]
	partial class StatisticsController
	{
		[Outlet]
		AppKit.NSView AngularVelocityAverageChart { get; set; }

		[Outlet]
		AppKit.NSView AngularVelocityChart { get; set; }

		[Outlet]
		AppKit.NSView AngularVelocityMedianChart { get; set; }

		[Outlet]
		AppKit.NSView AngularVelocityStandardDiviationChart { get; set; }

		[Outlet]
		AppKit.NSTextField MoreDataRequiredLabel { get; set; }

		[Outlet]
		AppKit.NSView TurnsNumberChart { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (TurnsNumberChart != null) {
				TurnsNumberChart.Dispose ();
				TurnsNumberChart = null;
			}

			if (MoreDataRequiredLabel != null) {
				MoreDataRequiredLabel.Dispose ();
				MoreDataRequiredLabel = null;
			}

			if (AngularVelocityChart != null) {
				AngularVelocityChart.Dispose ();
				AngularVelocityChart = null;
			}

			if (AngularVelocityMedianChart != null) {
				AngularVelocityMedianChart.Dispose ();
				AngularVelocityMedianChart = null;
			}

			if (AngularVelocityAverageChart != null) {
				AngularVelocityAverageChart.Dispose ();
				AngularVelocityAverageChart = null;
			}

			if (AngularVelocityStandardDiviationChart != null) {
				AngularVelocityStandardDiviationChart.Dispose ();
				AngularVelocityStandardDiviationChart = null;
			}
		}
	}
}
