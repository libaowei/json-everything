using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json.Schema.HyperSchema
{
	[SchemaKeyword(Name)]
	[SchemaDraft(Draft.Draft201909)]
	[SchemaDraft(Draft.Draft202012)]
	[Vocabulary(Vocabularies.HyperSchema201909Id)]
	[JsonConverter(typeof(BaseKeywordJsonConverter))]
	public class BaseKeyword : IJsonSchemaKeyword
	{
		internal const string Name = "base";

		public string Template { get; }

		public void Validate(ValidationContext context)
		{
			throw new NotImplementedException();
		}
	}

	internal class BaseKeywordJsonConverter : JsonConverter<BaseKeyword>
	{
		public override BaseKeyword Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, BaseKeyword value, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}
	}
}