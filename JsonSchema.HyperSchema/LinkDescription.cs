using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Json.Pointer;

namespace Json.Schema.HyperSchema
{
	//[JsonConverter(typeof(LinkJsonConverter))]
	public class LinkDescription
	{
		private const string DefaultSubmissionMediaType = "application/json";

		public string Anchor { get; set; }
		public JsonPointer AnchorPointer { get; set; }
		public List<string> Rel { get; }
		public string Href { get; }
		public JsonSchema HrefSchema { get; set; }
		public Dictionary<string, MaybeRelativeJsonPointer> TemplatePointers { get; set; }
		public List<string> TemplateRequired { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public JsonSchema TargetSchema { get; set; }
		public string TargetMediaType { get; set; }
		public object TargetHints { get; set; }
		public JsonSchema HeaderSchema { get; set; }
		public string SubmissionMediaType { get; set; }
		public JsonSchema SubmissionSchema { get; set; }
		public string Comment { get; set; }

		public LinkDescription(string rel, string href)
		{
			Href = href;
			Rel = new List<string> {rel};
		}

		public LinkDescription(List<string> rel, string href)
		{
			Rel = rel;
			Href = href;
		}
	}

	public class LinkJsonConverter : JsonConverter<LinkDescription>
	{
		public override LinkDescription Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, LinkDescription value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}
	}
}