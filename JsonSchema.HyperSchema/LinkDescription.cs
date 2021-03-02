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
		// these might be a defined set
		// these are definitely reserved
		// https://www.iana.org/assignments/link-relations/link-relations.xhtml
		// but it could be a uri
		public List<string> Rel { get; }
		// URI that can replace or amend the base
		public UriTemplate Href { get; }
		// provides validation on template variable values
		public JsonSchema HrefSchema { get; set; }
		// These map template var names to pointers where the appropriate
		// value can be found in the instance at that location
		// if the value is not in the instance, empty string is used
		public Dictionary<string, MaybeRelativeJsonPointer> TemplatePointers { get; set; }
		// describe variable that must be in the uri template
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

		public LinkDescription(string rel, UriTemplate href)
		{
			Href = href;
			Rel = new List<string> {rel};
		}

		public LinkDescription(List<string> rel, UriTemplate href)
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