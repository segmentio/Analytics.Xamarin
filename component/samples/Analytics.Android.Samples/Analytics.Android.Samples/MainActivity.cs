using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Segment;

namespace Analytics.Android.Samples
{
	[Activity (Label = "Analytics.Android.Samples", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// initialize the Analytics singleton with your Segment project's write key
			Segment.Analytics.Initialize ("g0nn82npae");

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
				Segment.Analytics.Client.Track("userId", "Android Track Button Clicked");
			};
		}
	}
}


