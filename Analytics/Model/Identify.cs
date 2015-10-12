using Newtonsoft.Json;

namespace Segment.Model
{
    public class Identify : BaseAction
    {
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

        [JsonProperty(PropertyName = "traits")]
		public Traits Traits { get; set; }

        internal Identify(string userId,
		                  Traits traits, 
						  Options options)
	
			: base("identify", options)
        {
			UserId = userId;
            Traits = traits ?? new Traits();
        }
    }
}
