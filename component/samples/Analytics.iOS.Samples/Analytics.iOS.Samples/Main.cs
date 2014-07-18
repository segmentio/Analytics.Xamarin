using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Segment;

namespace Analytics.OS.Samples
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{

			// initialize the Analytics singleton with Segment's write key
			Segment.Analytics.Initialize ("g0nn82npae");

			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
