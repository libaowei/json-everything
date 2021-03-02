using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json.Schema.HyperSchema
{
	[SchemaKeyword(Name)]
	[SchemaPriority(10)]
	[SchemaDraft(Draft.Draft201909)]
	[SchemaDraft(Draft.Draft202012)]
	[Vocabulary(Vocabularies.HyperSchema201909Id)]
	[JsonConverter(typeof(LinksKeywordJsonConverter))]
	public class LinksKeyword : IJsonSchemaKeyword, IEquatable<LinksKeyword>
	{
		internal const string Name = "links";

		// rel must be unique across the array
		public IReadOnlyList<LinkDescription> Links { get; }

		public LinksKeyword(IEnumerable<LinkDescription> links)
		{
			Links = links.ToList();
		}

		public void Validate(ValidationContext context)
		{
			// get annotation result of base

			throw new NotImplementedException();
		}

		public bool Equals(LinksKeyword other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Links.SequenceEqual(other.Links);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as LinksKeyword);
		}

		public override int GetHashCode()
		{
			return Links != null ? Links.GetHashCode() : 0;
		}
	}

	public class LinksKeywordJsonConverter : JsonConverter<LinksKeyword>
	{
		public override LinksKeyword Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray)
				throw new JsonException("Expected array");

			var links = JsonSerializer.Deserialize<List<LinkDescription>>(ref reader, options);
			return new LinksKeyword(links);
		}

		public override void Write(Utf8JsonWriter writer, LinksKeyword value, JsonSerializerOptions options)
		{
			writer.WritePropertyName(LinksKeyword.Name);
			writer.WriteStartArray();
			foreach (var link in value.Links)
			{
				JsonSerializer.Serialize(writer, link, options);
			}
			writer.WriteEndArray();
		}
	}
}
