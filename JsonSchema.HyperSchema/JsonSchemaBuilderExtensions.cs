using System.Collections.Generic;
using Tavis.UriTemplates;

namespace Json.Schema.HyperSchema
{
	public static class JsonSchemaBuilderExtensions
	{
		public static JsonSchemaBuilder Base(this JsonSchemaBuilder builder, string template)
		{
			builder.Add(new BaseKeyword(new UriTemplate(template)));
			return builder;
		}

		public static JsonSchemaBuilder Base(this JsonSchemaBuilder builder, UriTemplate template)
		{
			builder.Add(new BaseKeyword(template));
			return builder;
		}

		public static JsonSchemaBuilder Links(this JsonSchemaBuilder builder, params LinkDescription[] links)
		{
			builder.Add(new LinksKeyword(links));
			return builder;
		}

		public static JsonSchemaBuilder Links(this JsonSchemaBuilder builder, IEnumerable<LinkDescription> links)
		{
			builder.Add(new LinksKeyword(links));
			return builder;
		}
	}
}