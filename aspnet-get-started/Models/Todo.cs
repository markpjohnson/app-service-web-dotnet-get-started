using System;
using Newtonsoft.Json;

namespace aspnet_get_started.Models
{
	public class Todo
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("created")]
		public DateTime Created { get; set; }
	}
}