using System;

namespace Json.Schema.HyperSchema
{
	public class MetaSchemas
	{
		internal const string HyperSchemaUri201909Value = "https://json-schema.org/draft/2019-09/hyper-schema";

		public static readonly Uri HyperSchema201909Uri = new Uri(HyperSchemaUri201909Value);

		public static readonly Uri HyperSchemaVocab201909Uri = new Uri("https://json-schema.org/draft/2019-09/meta/hyper-schema");

		public static readonly Uri HyperSchemaLinks201909Uri = new Uri("https://json-schema.org/draft/2019-09/links");

		public static readonly JsonSchema HyperSchema201909 =
			new JsonSchemaBuilder()
				.Schema(HyperSchema201909Uri)
				.Id(HyperSchema201909Uri)
				.Vocabulary(
					(Schema.Vocabularies.Core201909Id, true),
					(Schema.Vocabularies.Applicator201909Id, true),
					(Schema.Vocabularies.Validation201909Id, true),
					(Schema.Vocabularies.Metadata201909Id, true),
					(Schema.Vocabularies.Format201909Id, false),
					(Schema.Vocabularies.Content201909Id, true),
					("https://json-schema.org/draft/2019-09/vocab/hyper-schema", true)
				)
				.RecursiveAnchor()
				.Title("JSON Hyper-Schema")
				.AllOf(
					new JsonSchemaBuilder().Ref(Schema.MetaSchemas.Draft201909Id),
					new JsonSchemaBuilder().Ref(HyperSchemaVocab201909Uri)
				)
				.Links(new Link("self", "{+%24id}"));

		public static readonly JsonSchema HyperSchemaVocab201909 =
			new JsonSchemaBuilder()
				.Schema(HyperSchema201909Uri)
				.Id(HyperSchemaVocab201909Uri)
				.Vocabulary(("https://json-schema.org/draft/2019-09/vocab/hyper-schema", true))
				.RecursiveAnchor()
				.Title("JSON Hyper-Schema Vocabulary Schema")
				.Type(SchemaValueType.Object | SchemaValueType.Boolean)
				.Properties(
					("base", new JsonSchemaBuilder()
							.Type(SchemaValueType.String)
							.Format(Formats.UriTemplate)
					),
					("links", new JsonSchemaBuilder()
							.Type(SchemaValueType.Array)
							.Items(new JsonSchemaBuilder().Ref(HyperSchemaLinks201909Uri))
					)
				)
				.Links(new Link("self", "{+%24id}"));

		public static readonly JsonSchema HyperSchemaLinks201909 =
			new JsonSchemaBuilder()
				.Schema(HyperSchema201909Uri)
				.Id(HyperSchemaLinks201909Uri)
				.Title("Link Description Object")
				.AllOf(
					new JsonSchemaBuilder().Required("rel", "href"),
					new JsonSchemaBuilder().Ref("#/$defs/noRequiredFields")
				)
				.Defs(
					("noRequiredFields", new JsonSchemaBuilder()
						.Type(SchemaValueType.Object)
						.Properties(
							("anchor", new JsonSchemaBuilder()
								.Type(SchemaValueType.String)
								.Format(Formats.UriTemplate)
							),
							("anchorPointer", new JsonSchemaBuilder()
								.Type(SchemaValueType.String)
								.AnyOf(new JsonSchemaBuilder().Format(Formats.JsonPointer),
									new JsonSchemaBuilder().Format(Formats.RelativeJsonPointer))
							),
							("rel", new JsonSchemaBuilder()
								.AnyOf(new JsonSchemaBuilder().Type(SchemaValueType.String),
									new JsonSchemaBuilder()
										.Type(SchemaValueType.Array)
										.Items(new JsonSchemaBuilder().Type(SchemaValueType.String))
										.MinItems(1))
							),
							("href", new JsonSchemaBuilder()
								.Type(SchemaValueType.String)
								.Format(Formats.UriTemplate)
							),
							("hrefSchema", new JsonSchemaBuilder()
								.RecursiveRef(HyperSchema201909Uri)
								.Default(false)
							),
							("templatePoitners", new JsonSchemaBuilder()
								.Type(SchemaValueType.Object)
								.AdditionalProperties(new JsonSchemaBuilder()
									.Type(SchemaValueType.String)
									.AnyOf(new JsonSchemaBuilder().Format(Formats.JsonPointer),
										new JsonSchemaBuilder().Format(Formats.RelativeJsonPointer))
								)
							),
							("templateRequired", new JsonSchemaBuilder()
								.Type(SchemaValueType.Array)
								.Items(new JsonSchemaBuilder().Type(SchemaValueType.String))
								.UniqueItems(true)
							),
							("title", new JsonSchemaBuilder().Type(SchemaValueType.String)),
							("description", new JsonSchemaBuilder().Type(SchemaValueType.String)),
							("targetSchema", new JsonSchemaBuilder()
								.RecursiveRef(HyperSchema201909Uri)
								.Default(true)
							),
							("targetMediaType", new JsonSchemaBuilder().Type(SchemaValueType.String)),
							("targetHints", new JsonSchemaBuilder()),
							("headerSchema", new JsonSchemaBuilder()
								.RecursiveRef(HyperSchema201909Uri)
								.Default(true)
							),
							("submissionMediaType", new JsonSchemaBuilder()
								.Type(SchemaValueType.String)
								.Default("application/json")
							),
							("submissionSchema", new JsonSchemaBuilder()
								.RecursiveRef(HyperSchema201909Uri)
								.Default(true)
							),
							("comment", new JsonSchemaBuilder().Type(SchemaValueType.String))
						)
					)
				);
	}
}
