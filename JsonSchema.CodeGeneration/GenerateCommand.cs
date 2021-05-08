using System.IO;
using System.Text;
using CommandLine;

namespace Json.Schema.CodeGeneration
{
	public class GenerateCommand
	{
		[Option('s', "schema-file", Required = true, HelpText = "The path to the file containing the schema.")]
		public string SchemaFile { get; set; }
		[Option('o', "output-file", Required = true, HelpText = "The output file name.")]
		public string OutputFile { get; set; }

		public bool Validate(out string errorMessage)
		{
			var valid = true;
			var sb = new StringBuilder();
			if (!File.Exists(SchemaFile))
			{
				sb.AppendLine($"Cannot find schema file `{SchemaFile}`");
				valid = false;
			}

			errorMessage = sb.ToString();
			return valid;
		}
	}
}