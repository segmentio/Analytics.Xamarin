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
		private Traits Traits { get; set; }

		internal Group(string userId, 
					   string groupId,
					   Traits traits, 
					   Options options)
			: base("group", options)
        {
			UserId = userId;
			GroupId = groupId;
			Traits = traits ?? new Traits();
        }
    }
}
