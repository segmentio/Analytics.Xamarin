﻿using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Segment.Model
{
	public class Group : BaseAction
	{
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "groupId")]
		private string GroupId { get; set; }

		[JsonProperty(PropertyName = "traits")]
		private IDictionary<string, object> Traits { get; set; }

		internal Group(string userId,
					   string groupId,
					   IDictionary<string, object> traits,
					   Options options)
			: base("group", options)
		{
			this.UserId = userId;
			this.GroupId = groupId;
			this.Traits = traits ?? new Traits();
		}
	}
}
