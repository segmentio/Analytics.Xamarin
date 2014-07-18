using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Segment;

namespace Analytics.OS.Samples
{
	public partial class Analytics_OS_SamplesViewController : UIViewController
	{
		public Analytics_OS_SamplesViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}
			
		partial void UIButton6_TouchUpInside (UIButton sender)
		{
			// fire off an event every time the button is clicked
			Segment.Analytics.Client.Track("userId", "Track Button Clicked");
		}
		#endregion
	}
}

