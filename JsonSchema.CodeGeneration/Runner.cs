using System.Collections.Generic;

namespace Json.Schema.CodeGeneration
{
	public class Runner : IRunner
	{
		private readonly ISchemaLoader _schemaLoader;
		private readonly IOutputChannel _output;
		private readonly IEnumerable<IGenerationVisitor> _generationVisitors;

		public Runner(ISchemaLoader schemaLoader,
			IOutputChannel output,
			IEnumerable<IGenerationVisitor> generationVisitors)
		{
			_schemaLoader = schemaLoader;
			_output = output;
			_generationVisitors = generationVisitors;
		}

		public void Run(GenerateCommand command)
		{
			var schema = _schemaLoader.Load(command.SchemaFile);
		}
	}

	public class PropertiesProcessor : IGenerationVisitor
	{
		
	}

	public interface IGenerationVisitor
	{

	}
}