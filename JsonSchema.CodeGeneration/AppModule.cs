using Autofac;

namespace Json.Schema.CodeGeneration
{
	public class AppModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Runner>().AsImplementedInterfaces();
			builder.RegisterType<SchemaLoader>().AsImplementedInterfaces();
		}
	}
}