using Autofac;

namespace Json.Schema.CodeGeneration
{
	// ReSharper disable once InconsistentNaming
	public class IOModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<SchemaLoader>().AsImplementedInterfaces();
			builder.RegisterType<ConsoleChannel>().AsImplementedInterfaces();
		}
	}
}