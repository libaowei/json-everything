namespace Json.Schema.CodeGeneration
{
	public interface IOutputChannel
	{
		void WriteLine();
		void WriteLine(string content);
	}
}