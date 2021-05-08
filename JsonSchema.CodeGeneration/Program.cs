using System;
using Autofac;
using CommandLine;

namespace Json.Schema.CodeGeneration
{
	public static class Program
	{
		private static IContainer _container = null!;

		static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterModule<AppModule>();

			_container = builder.Build();

			Parser.Default.ParseArguments<GenerateCommand>(args)
				.WithParsed(Generate);
		}

		private static void Generate(GenerateCommand command)
		{
			if (!command.Validate(out string errorMessage))
			{
				Console.WriteLine(errorMessage);
				Environment.Exit(1);
			}

			var runner = _container.Resolve<IRunner>();

			runner.Run(command);
		}
	}
}