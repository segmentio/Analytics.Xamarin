using Newtonsoft.Json;

namespace Segment.Model
{
	public class Screen : BaseAction
    {
		[JsonProperty(PropertyName = "userId")]
		public string UserId { get; private set; }

		[JsonProperty(PropertyName = "name")]
        private string Name { get; set; }

		[JsonProperty(PropertyName = "category")]
		private string Category { get; set; }

        [JsonProperty(PropertyName = "properties")]
        private Properties Properties { get; set; }

		internal Screen(string userId, 
						string name,
					    string category,
            		    Properties properties, 
					    Options options)

			: base("screen", options)
		{
			UserId = userId;
			Name = name;
			Category = category;
            Properties = properties ?? new Properties();
        }
    }
}
