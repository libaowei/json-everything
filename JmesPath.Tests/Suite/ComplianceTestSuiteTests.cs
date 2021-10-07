using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Json.More;
using NUnit.Framework;

namespace Json.JmesPath.Tests.Suite
{
	public class ComplianceTestSuiteTests
	{
		private const string _testsFolder = @"../../../../ref-repos/jmespath.test/tests";
		private static readonly string[] _notSupported =
			{
			};

		public static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				var allTests = new List<ComplianceTestCase>();
				var files = Directory.GetFiles(_testsFolder).Where(x => !x.Contains("benchmarks"));
				foreach (var file in files)
				{
					var fileText = File.ReadAllText(file);
					var suite = JsonSerializer.Deserialize<List<ComplianceTestScenario>>(fileText, new JsonSerializerOptions
					{
						AllowTrailingCommas = true,
						Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
						PropertyNameCaseInsensitive = true
					});
					allTests.AddRange(suite.SelectMany(x => x.Cases.Select(c =>
					{
						c.Given = x.Given;
						return c;
					})));
				}

				return allTests.Select(x => new TestCaseData(x));
			}
		}

		[TestCaseSource(nameof(TestCases))]
		public void Run(ComplianceTestCase testCase)
		{
			if (_notSupported.Contains(testCase.Expression))
				Assert.Inconclusive("This case will not be supported.");

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(testCase);
			Console.WriteLine();

			PathResult actual = null;

			var time = Debugger.IsAttached ? int.MaxValue : 100;
			using var cts = new CancellationTokenSource(time);
			Task.Run(() =>
			{
				if (!JsonPath.TryParse(testCase.Expression, out var path)) return;

				if (testCase.Given.ValueKind == JsonValueKind.Undefined) return;

				actual = path.Evaluate(testCase.Given);
			}, cts.Token).Wait(cts.Token);

			//if (path != null && testCase.InvalidSelector)
			//	Assert.Inconclusive($"{testCase.Selector} is not a valid path but was parsed without error.");

			//if (actual == null)
			//{
			//	if (testCase.InvalidSelector) return;
			//	Assert.Fail($"Could not parse path: {testCase.Selector}");
			//}

			var actualValues = actual.Matches.Select(m => m.Value).AsJsonElement();
			Console.WriteLine($"Actual (values): {actualValues}");
			Console.WriteLine();
			Console.WriteLine($"Actual: {JsonSerializer.Serialize(actual)}");
			//if (testCase.InvalidSelector)
			//	Assert.Fail($"{testCase.Selector} is not a valid path.");

			var expected = testCase.Result;
			Assert.IsTrue(expected.IsEquivalentTo(actualValues));
		}
	}
}
