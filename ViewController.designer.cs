// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace calculator
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField Label { get; set; }

		[Action ("ACBtn:")]
		partial void ACBtn (AppKit.NSButton sender);

		[Action ("btn:")]
		partial void btn (AppKit.NSButton sender);

		[Action ("commaBtn:")]
		partial void commaBtn (AppKit.NSButton sender);

		[Action ("divideBtn:")]
		partial void divideBtn (AppKit.NSButton sender);

		[Action ("eightBtn:")]
		partial void eightBtn (AppKit.NSButton sender);

		[Action ("equalBtn:")]
		partial void equalBtn (AppKit.NSButton sender);

		[Action ("fiveBtn:")]
		partial void fiveBtn (AppKit.NSButton sender);

		[Action ("fourBtn:")]
		partial void fourBtn (AppKit.NSButton sender);

		[Action ("minusBtn:")]
		partial void minusBtn (AppKit.NSButton sender);

		[Action ("multiplyBtn:")]
		partial void multiplyBtn (AppKit.NSButton sender);

		[Action ("nineBtn:")]
		partial void nineBtn (AppKit.NSButton sender);

		[Action ("oneBtn:")]
		partial void oneBtn (AppKit.NSButton sender);

		[Action ("plusBtn:")]
		partial void plusBtn (AppKit.NSButton sender);

		[Action ("sevenBtn:")]
		partial void sevenBtn (AppKit.NSButton sender);

		[Action ("sixBtn:")]
		partial void sixBtn (AppKit.NSButton sender);

		[Action ("threeBtn:")]
		partial void threeBtn (AppKit.NSButton sender);

		[Action ("twoBtn:")]
		partial void twoBtn (AppKit.NSButton sender);

		[Action ("zeroBtn:")]
		partial void zeroBtn (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Label != null) {
				Label.Dispose ();
				Label = null;
			}
		}
	}
}
