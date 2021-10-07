using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Json.More;

namespace Json.JmesPath
{
	/// <summary>
	/// The results of a JSON Path evaluation against a JSON instance.
	/// </summary>
	[JsonConverter(typeof(PathResultJsonConverter))]
	public class PathResult
	{
		/// <summary>
		/// The list of matches.
		/// </summary>
		public IReadOnlyList<PathMatch>? Matches { get; }
		/// <summary>
		/// An error, if any, that occurred during evaluation.
		/// </summary>
		public string? Error { get; }

		internal PathResult(IReadOnlyList<PathMatch> matches)
		{
			Matches = matches;
		}
		internal PathResult(string error)
		{
			Error = error;
		}
	}

	internal class PathResultJsonConverter : JsonConverter<PathResult>
	{
		public override PathResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			throw new NotImplementedException();
		}

		public override void Write(Utf8JsonWriter writer, PathResult value, JsonSerializerOptions options)
		{
			if (!string.IsNullOrWhiteSpace(value.Error))
			{
				writer.WriteStringValue(value.Error);
				return;
			}

			if (value.Matches!.Count == 0)
			{
				writer.WriteNullValue();
				return;
			}

			if (value.Matches.Count == 1)
			{
				writer.WriteValue(value.Matches[0].Value);
				return;
			}

			writer.WriteStartArray();
			foreach (var match in value.Matches)
			{
				writer.WriteValue(match.Value);
			}
			writer.WriteEndArray();
		}
	}
}