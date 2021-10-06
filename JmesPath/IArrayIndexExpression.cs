using System.Collections.Generic;
using System.Text.Json;

namespace Json.JmesPath
{
	internal interface IArrayIndexExpression : IIndexExpression
	{
		IEnumerable<int> GetIndices(JsonElement array);
	}
}