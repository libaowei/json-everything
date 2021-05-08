using System;

namespace Json.Schema.CodeGeneration
{
	public class ConsoleChannel : IOutputChannel
	{
		public void WriteLine() => Console.WriteLine();
		public void WriteLine(string content) => Console.WriteLine(content);
	}
}