using System.Linq;
using System.Reflection;

namespace Json.Schema.HyperSchema
{
	public class Vocabularies
	{
		public const string HyperSchema201909Id = "";

		public static readonly Vocabulary HyperSchema201909;

		static Vocabularies()
		{
			var keywords = typeof(IJsonSchemaKeyword)
				.Assembly
				.DefinedTypes
				.Where(t => typeof(IJsonSchemaKeyword).IsAssignableFrom(t) &&
				            !t.IsAbstract &&
				            !t.IsInterface)
				.Select(t => new
				{
					Type = t,
					Vocabularies = t.GetCustomAttributes<VocabularyAttribute>()
				})
				.ToList();

			HyperSchema201909 = new Vocabulary(
				HyperSchema201909Id,
				keywords.Where(k => k.Vocabularies.Any(v => v.Id.OriginalString == HyperSchema201909Id))
					.Select(k => k.Type));
		}
	}
}