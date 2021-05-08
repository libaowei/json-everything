using System;
using Moq;
using NUnit.Framework;

namespace Json.Schema.CodeGeneration.Tests
{
	public class RunnerTests
	{
		[Test]
		public void BasicObject()
		{
			var schema = new JsonSchemaBuilder()
				.Type(SchemaValueType.Object)
				.Title("MyClass")
				.Properties(
					("IntProp", new JsonSchemaBuilder().Type(SchemaValueType.Integer)),
					("StringProp", new JsonSchemaBuilder().Type(SchemaValueType.String))
				);
			var schemaLoader = new Mock<ISchemaLoader>();
			schemaLoader.Setup(l => l.Load(It.IsAny<string>()))
				.Returns(schema);

			var expected = @"public class MyClass
{
	public int IntProp { get; set; }
	public string StringProp { get; set; }
}
";

			var channel = new StringBuilderChannel();
			var runner = new Runner(schemaLoader.Object, channel);

			var command = new GenerateCommand
			{
				SchemaFile = "schema.json",
				OutputFile = "output.json"
			};

			runner.Run(command);

			var output = channel.ToString();

			Assert.AreEqual(expected, output);
		}
	}
}