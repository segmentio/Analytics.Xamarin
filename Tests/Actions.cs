using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Segment;
using Segment.Model;

namespace Segment.Test
{
	public class Actions
	{
		private static Random random = new Random();

		public static Properties Properties()
		{
			return new Properties() {
				{ "Success", true },
				{ "When", DateTime.Now }
			};
		}

		public static Traits Traits()
		{
			return new Traits() {
				{ "Subscription Plan", "Free" },
				{ "Friends", 30 },
				{ "Joined", DateTime.Now },
				{ "Cool", true },
				{ "Company", new Dict () { { "name", "Initech, Inc " } } },
				{ "Revenue", 40.32 },
				{ "Don't Submit This, Kids", new UnauthorizedAccessException () }
			};
		}

		public static Options Options()
		{
			return new Options()
				.SetTimestamp(DateTime.Now)
				.SetIntegration("all", false)
				.SetIntegration("Mixpanel", true)
				.SetIntegration("Salesforce", true)
				.SetContext(new Context()
					.Add("ip", "12.212.12.49")
					.Add("language", "en-us")
			);
		}

		public static void Identify(IClient client)
		{
			client.Identify("user", Traits(), Options());
			Analytics.Client.Flush();
		}

		public static void Group(IClient client)
		{
			client.Group("user", "group", Traits(), Options());
			Analytics.Client.Flush();
		}

		public static void Track(IClient client)
		{
			client.Track("user", "Ran .NET test", Properties(), Options());
		}

		public static void Alias(IClient client)
		{
			client.Alias("previousId", "to", null);
		}

		public static void Page(IClient client)
		{
			client.Page("user", "name", "category", Properties(), Options());
		}

		public static void Screen(IClient client)
		{
			client.Screen("user", "name", "category", Properties(), Options());
		}

		public static void Random(IClient client)
		{
			switch (random.Next(0, 6))
			{
				case 0:
					Identify(client);
					return;
				case 1:
					Track(client);
					return;
				case 2:
					Alias(client);
					return;
				case 3:
					Group(client);
					return;
				case 4:
					Page(client);
					return;
				case 5:
					Screen(client);
					return;
			}
		}
	}
}