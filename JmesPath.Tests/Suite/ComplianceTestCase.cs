using System.Collections.Generic;
using System.Text.Json;
using Json.More;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable 8618

namespace Json.JmesPath.Tests.Suite
{
	public class ComplianceTestCase
	{
		public JsonElement Given { get; set; }
		public string Expression { get; set; }
		public JsonElement Result { get; set; }
		public string Error { get; set; }

		public override string ToString()
		{
			return string.IsNullOrWhiteSpace(Error)
				? $"Given:      {Given.ToJsonString()}\n" +
				  $"Expression: {Expression}\n" +
				  $"Result:     {Result.ToJsonString()}"
				: $"Given:      {Given.ToJsonString()}\n" +
				  $"Expression: {Expression}\n" +
				  $"Error:      {Error}";
		}
	}

	public class ComplianceTestScenario
	{
		public JsonElement Given { get; set; }
		public List<ComplianceTestCase> Cases { get; set; }
	}
}