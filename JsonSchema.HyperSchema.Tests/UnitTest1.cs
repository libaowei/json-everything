using Json.More;
using Json.Schema.Tests;
using NUnit.Framework;

namespace Json.Schema.HyperSchema.Tests
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			JsonSchema schema = new JsonSchemaBuilder()
				.Type(SchemaValueType.Object)
				.Properties(
					("id", new JsonSchemaBuilder()
						.Type(SchemaValueType.Number)
						.ReadOnly(true)
					)
				)
				.Links(new LinkDescription("self", "thing/{id}"));

			var instance = new {id = 1234}.ToJsonDocument().RootElement;

			var result = schema.Validate(instance, new ValidationOptions {OutputFormat = OutputFormat.Detailed});

			result.AssertValid();
		}
	}
}