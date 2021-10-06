using System.Collections.Generic;

namespace Json.JmesPath
{
	internal class LocalNodeSelector : SelectorBase
	{
		protected override IEnumerable<PathMatch> ProcessMatch(PathMatch match)
		{
			return new[] {match};
		}

		public override string ToString()
		{
			return "@";
		}
	}
}