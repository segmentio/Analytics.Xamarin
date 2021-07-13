using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Segment.Model
{
	public class Screen : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "category")]
		public string Category { get; set; }

		[JsonProperty(PropertyName = "properties")]
		public IDictionary<string, object> Properties { get; set; }

		[JsonConstructor]
		internal Screen(string userId,
						string name,
						string category,
						IDictionary<string, object> properties,
						Options options)

			: base("screen", options)
		{
			this.UserId = userId;
			this.Name = name;
			this.Category = category;
			this.Properties = properties ?? new Properties();
		}
	}
}
