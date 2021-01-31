using System.Collections.Generic;
using Json.Pointer;

namespace Json.Schema.HyperSchema
{
	public class Link
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

		public Link(string rel, string href)
		{
			Href = href;
			Rel = new List<string> {rel};
		}

		public Link(List<string> rel, string href)
		{
			Rel = rel;
			Href = href;
		}
	}
}