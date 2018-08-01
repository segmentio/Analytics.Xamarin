using System;
using Plugin.DeviceInfo;

namespace Segment.Model
{
	public class Context : Dict
	{
		/// <summary>
		/// Provides additional information about the context of an analytics call, 
		/// such as the visitor's ip or language.
		/// </summary>
		public Context()
		{
			// default the context library
			this.Add("library", new Dict() {
				{ "name", "Analytics.Xamarin" },
				{ "version", Analytics.VERSION }
			});

			// Add os info
			var os = Plugin.DeviceInfo.CrossDeviceInfo.Current.Version.Split(':');
			if (os != null && os.Length == 2)
			{
				this.Add("os", new Dict()
				{
					{ "name", os[0] },
					{ "version", os[1] }
				});
			}
		}

		public new Context Add(string key, object val)
		{
			base.Add(key, val);
			return this;
		}
	}
}
