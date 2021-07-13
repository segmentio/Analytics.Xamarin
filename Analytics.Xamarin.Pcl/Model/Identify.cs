using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Segment.Model
{
	public class Identify : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "traits")]
		public IDictionary<string, object> Traits { get; set; }

		[JsonConstructor]
		internal Identify(string userId,
						  IDictionary<string, object> traits,
						  Options options)

			: base("identify", options)
		{
			this.UserId = userId;
			this.Traits = traits ?? new Traits();
		}
	}
}
