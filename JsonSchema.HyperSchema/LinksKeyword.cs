using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json.Schema.HyperSchema
{
	[SchemaKeyword(Name)]
	[SchemaDraft(Draft.Draft201909)]
	[SchemaDraft(Draft.Draft202012)]
	[Vocabulary(Vocabularies.HyperSchema201909Id)]
	[JsonConverter(typeof(LinksKeywordJsonConverter))]
	public class LinksKeyword : IJsonSchemaKeyword
	{
		internal const string Name = "links";

		public List<Link> Links { get; }

		public void Validate(ValidationContext context)
		{
			throw new NotImplementedException();
		}
	}

	public class LinksKeywordJsonConverter : JsonConverter<LinksKeyword>
	{
		public override LinksKeyword Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, LinksKeyword value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}
	}
}
