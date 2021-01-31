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
	public class BaseKeyword : IJsonSchemaKeyword, IEquatable<BaseKeyword>
	{
		internal const string Name = "base";

		public string Template { get; }

		public BaseKeyword(string template)
		{
			Template = template;
		}

		public void Validate(ValidationContext context)
		{
			throw new NotImplementedException();
		}

		public bool Equals(BaseKeyword other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Template == other.Template;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as BaseKeyword);
		}

		public override int GetHashCode()
		{
			return Template?.GetHashCode() ?? 0;
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