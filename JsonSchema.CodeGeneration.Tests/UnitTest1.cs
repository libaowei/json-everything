using System.Collections.Generic;
using System.IO;
using Autofac;
using Moq;
using NUnit.Framework;

namespace Json.Schema.CodeGeneration.Tests
{
	public class IntegrationTests
	{
		private const string TestCasesPath = "Integration";
		private IContainer _container;
		private Mock<ISchemaLoader> _schemaLoader;
		private StringBuilderChannel _channel;

		public void Setup()
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<AppModule>();
			builder.RegisterModule<IOModule>();

			_schemaLoader = new Mock<ISchemaLoader>();
			_channel = new StringBuilderChannel();

			builder.RegisterInstance(_schemaLoader.Object).AsImplementedInterfaces();
			builder.RegisterInstance(_channel).AsImplementedInterfaces();

			_container = builder.Build();
		}

		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				var testsPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, TestCasesPath)
					.AdjustForPlatform();
				var schemas = Directory.GetFiles(testsPath, "*.json");
				foreach (var schema in schemas)
				{
					var caseName = Path.GetFileNameWithoutExtension(schema);
					var expectedFileName = $"{caseName}.cs";
					yield return new TestCaseData(schema, expectedFileName);
				}
			}
		}
			
		[TestCaseSource(nameof(TestCases))]
		public void Run(string schemaFile, string expectedFile)
		{
			var schema = JsonSchema.FromFile(schemaFile);
			var expected = File.ReadAllText(expectedFile);

			_schemaLoader.Setup(l => l.Load(It.IsAny<string>()))
				.Returns(schema);

			var runner = _container.Resolve<IRunner>();

			var command = new GenerateCommand
			{
				SchemaFile = "schema.json",
				OutputFile = "output.json"
			};

			runner.Run(command);

			var output = _channel.ToString();

			Assert.AreEqual(expected, output);
		}
	}
}