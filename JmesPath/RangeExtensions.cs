using System;

namespace Json.JmesPath
{
	internal static class RangeExtensions
	{
		public static string ToPathString(this Index index)
		{
			return index.IsFromEnd ? $"-{index.Value}" : index.Value.ToString();
		}
	}
}