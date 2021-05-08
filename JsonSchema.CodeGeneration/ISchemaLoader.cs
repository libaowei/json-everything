namespace Json.Schema.CodeGeneration
{
	public interface ISchemaLoader
	{
		JsonSchema Load(string fileName);
	}
}