using System.Collections.Generic;
using System.Text.Json;

namespace Json.JmesPath
{
	internal interface IObjectIndexExpression : IIndexExpression
	{
		IEnumerable<string> GetProperties(JsonElement obj);
	}
}