using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Segment.Model
{
	public class Alias : BaseAction
	{
		[JsonProperty(PropertyName = "previousId")]
		public string PreviousId { get; set; }

		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; set; }

		[JsonConstructor]
		internal Alias(string previousId, string userId, Options options)
			: base("alias", options)
		{
			this.PreviousId = previousId;
			this.UserId = userId;
		}
	}
}
