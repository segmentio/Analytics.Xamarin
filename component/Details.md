[Segment](https://segment.com) is a better analytics API. Instrument your app once and install hundreds of analytics tools with the flip of a switch, instead of weeks of extra development work.

If you're using tools like Google Analytics or Omniture, your code starts to look like this:

```csharp
GAI.SharedInstance.DefaultTracker.Set (GAIConstants.ScreenName, "Login");
GAI.SharedInstance.DefaultTracker.Send (GAIDictionaryBuilder.CreateAppView ().Build ());
AppMeasurement omniture = new AppMeasurement();
omniture.account = "myCorp";
omniture.dc = "d1";
omniture.pageName = "Login";
omniture.track();
Tracker tracker = new Mixpanel.Tracker("mipxanel-api-key");
tracker.Track("Login");
```

Our cleaner API turns all of this into one call: 

```csharp
Analytics.Screen("userId", "Login");
```

### Features

- A beautiful analytics API 
- Integrate Google Analytics, Omniture, Mixpanel, and [hundreds of other tools](https://segment.io/integrations) with the flick of a switch
- Access your analytics data using a clean format
- Combine web, mobile, and server data into a single data warehouse

### Portable Class Library

Our Xamarin Portable Class Library ([PCL](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/pcl/)) is the best way to integrate analytics into your Xamarin application. It lets you record analytics data from your C#, F#, and .NET code, and supports `PCL Profile 4.0 - Profile136`, which targets the following platforms:

- .NET Framework 4 or later
- Windows Phone 8 or later
- Silverlight 5
- Windows 8
- Windows Phone Silverlight 8
- Windows Store apps (Windows 8)
- Xamarin.Android
- Xamarin.iOS

### Get Started

To get started, create yourself a free [Segment](https://segment.io) account and check out our Xamarin [documentation](https://segment.io/docs/libraries/xamarin).

