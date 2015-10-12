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
        private Properties Properties { get; set; }

        internal Track(string userId, 
		               string eventName,
            		   Properties properties, 
					   Options options)

			: base("track", options)
        {
			UserId = userId;
            EventName = eventName;
            Properties = properties ?? new Properties();
        }
    }
}
