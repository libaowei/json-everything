namespace Json.Schema.CodeGeneration
{
	public class Runner : IRunner
	{
		private readonly ISchemaLoader _schemaLoader;
		private readonly IOutputChannel _output;

		public Runner(ISchemaLoader schemaLoader,
			IOutputChannel output)
		{
			_schemaLoader = schemaLoader;
			_output = output;
		}

		public void Run(GenerateCommand command)
		{
			
		}
	}
}