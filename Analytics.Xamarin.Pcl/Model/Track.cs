﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Segment.Model
{
	public class Track : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "event")]
		private string EventName { get; set; }

		[JsonProperty(PropertyName = "properties")]
		private IDictionary<string, object> Properties { get; set; }

		internal Track(string userId,
					   string eventName,
					   IDictionary<string, object> properties,
					   Options options)

			: base("track", options)
		{
			this.UserId = userId;
			this.EventName = eventName;
			this.Properties = properties ?? new Properties();
		}
	}
}
