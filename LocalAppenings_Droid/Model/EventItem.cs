using System;
using Newtonsoft.Json;

namespace LocalAppenings
{
	public class EventItem
	{
		public string ParseClassName { get{ return "Event"; } }

		[JsonProperty(PropertyName = "objectId")]
		public string objectId { get; set; }

		[JsonProperty(PropertyName = "address")]
		public string address { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string city { get; set; }

		[JsonProperty(PropertyName = "date")]
		public string date { get; set; }

		[JsonProperty(PropertyName = "location")]
		public string location { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string name { get; set; }

		[JsonProperty(PropertyName = "isPublic")]
		public bool isPublic { get; set; }

		[JsonProperty(PropertyName = "state")]
		public string state { get; set; }

		[JsonProperty(PropertyName = "zipcode")]
		public string zipcode { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string description { get; set; }


	}
}

