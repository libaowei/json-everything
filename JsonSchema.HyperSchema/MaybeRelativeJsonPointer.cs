using System.Text.Json;
using Json.Pointer;

namespace Json.Schema.HyperSchema
{
	public readonly struct MaybeRelativeJsonPointer
	{
		public JsonPointer? Pointer { get; }
		public RelativeJsonPointer? RelativePointer { get; }

		public MaybeRelativeJsonPointer(JsonPointer pointer)
		{
			Pointer = pointer;
			RelativePointer = null;
		}

		public MaybeRelativeJsonPointer(RelativeJsonPointer relativePointer)
		{
			Pointer = null;
			RelativePointer = relativePointer;
		}

		public JsonElement? Evaluate(JsonElement root)
		{
			return Pointer?.Evaluate(root) ?? RelativePointer?.Evaluate(root);
		}

		public static implicit operator MaybeRelativeJsonPointer(JsonPointer pointer)
		{
			return new MaybeRelativeJsonPointer(pointer);
		}

		public static implicit operator MaybeRelativeJsonPointer(RelativeJsonPointer relativePointer)
		{
			return new MaybeRelativeJsonPointer(relativePointer);
		}
	}
}