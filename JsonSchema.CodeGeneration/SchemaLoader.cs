namespace Json.Schema.CodeGeneration
{
	public class SchemaLoader : ISchemaLoader
	{
		public JsonSchema Load(string fileName) => JsonSchema.FromFile(fileName);
	}
}