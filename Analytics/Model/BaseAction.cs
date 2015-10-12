using System;
using Newtonsoft.Json;

namespace Segment.Model
{
    public abstract class BaseAction
    {
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName="messageId")]
		public string MessageId { get; private set; }
	
		[JsonProperty(PropertyName="timestamp")]
		public string Timestamp { get; private set; }

		[JsonProperty(PropertyName="context")]
		public Context Context { get; set; }

		[JsonProperty(PropertyName="integrations")]
		public Dict Integrations { get; set; }

		[JsonProperty(PropertyName = "anonymousId")]
		public string AnonymousId { get; private set; }

		internal BaseAction(string type, Options options)
		{
			options = options ?? new Options ();

			Type = type;
			MessageId = Guid.NewGuid ().ToString();
			if (options.Timestamp.HasValue)
				Timestamp = options.Timestamp.ToString ();
            else
                Timestamp = DateTime.Now.ToString("o");
			Context = options.Context;
			Integrations = options.Integrations;
			AnonymousId = options.AnonymousId;
        }
    }
}
