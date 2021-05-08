using System.Text;

namespace Json.Schema.CodeGeneration.Tests
{
	public class StringBuilderChannel : IOutputChannel
	{
		private readonly StringBuilder _builder = new StringBuilder();

		public void WriteLine() => _builder.AppendLine();

		public void WriteLine(string content) => _builder.AppendLine(content);

		public override string ToString() => _builder.ToString();
	}
}