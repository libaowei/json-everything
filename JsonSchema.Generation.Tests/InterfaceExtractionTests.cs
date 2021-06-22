using System;
using NUnit.Framework;

using static Json.Schema.Generation.Tests.AssertionExtensions;

namespace Json.Schema.Generation.Tests
{
	public class InterfaceExtractionTests
	{
		private interface IFoo
		{
			public int FooValue { get; set; }
		}

		private interface IBar
		{
			public int BarValue { get; set; }
		}

		private interface INoProps
		{
			public int Method();
		}

		private class FooAndBar : IFoo, IBar
		{
			public int FooValue { get; set; }
			public int BarValue { get; set; }
		}

		private class JustFoo : IFoo
		{
			public int FooValue { get; set; }
		}

		private class MultipleUsageTestTarget
		{
			public FooAndBar FooAndBar { get; set; }
			public JustFoo JustFoo { get; set; }
		}

		[Test]
		public void InterfacesAreExtractedIfUsedMoreThanOnce()
		{
			var expected = new JsonSchemaBuilder()
				.Type(SchemaValueType.Object)
				.Defs(
					(nameof(IFoo), new JsonSchemaBuilder()
						.Type(SchemaValueType.Object)
						.Properties(
							(nameof(IFoo.FooValue), new JsonSchemaBuilder().Type(SchemaValueType.Integer))
						)
					)
				)
				.Properties(
					(nameof(MultipleUsageTestTarget.FooAndBar), new JsonSchemaBuilder()
						.Ref("#/$defs/IFoo")
						.Properties(
							(nameof(IBar.BarValue), new JsonSchemaBuilder().Type(SchemaValueType.Integer))
						)
					),
					(nameof(MultipleUsageTestTarget.JustFoo), new JsonSchemaBuilder().Ref("#/$defs/IFoo"))
				)
				.Build();

			var actual = new JsonSchemaBuilder().FromType<MultipleUsageTestTarget>().Build();

			AssertEqual(expected, actual);
		}

		private class TwoJustFoos
		{
			public JustFoo JustFoo1 { get; set; }
			public JustFoo JustFoo2 { get; set; }
		}

		[Test]
		public void FullyDuplicatedTypeExtractedButNotInterface()
		{
			var expected = new JsonSchemaBuilder()
				.Type(SchemaValueType.Object)
				.Defs(
					(nameof(JustFoo), new JsonSchemaBuilder()
						.Type(SchemaValueType.Object)
						.Properties(
							(nameof(IFoo.FooValue), new JsonSchemaBuilder().Type(SchemaValueType.Integer))
						)
					)
				)
				.Properties(
					(nameof(TwoJustFoos.JustFoo1), new JsonSchemaBuilder().Ref("#/$defs/JustFoo")),
					(nameof(TwoJustFoos.JustFoo2), new JsonSchemaBuilder().Ref("#/$defs/JustFoo"))
				)
				.Build();

			var actual = new JsonSchemaBuilder().FromType<TwoJustFoos>().Build();

			AssertEqual(expected, actual);
		}

		private class TwoJustFoosOneWithAttributes
		{
			public JustFoo JustFoo1 { get; set; }
			[ReadOnly]
			public JustFoo JustFoo2 { get; set; }
		}

		[Test]
		public void FullyDuplicatedTypeExtractedButNotInterfaceWhenOneHasAttribute()
		{
			var expected = new JsonSchemaBuilder()
				.Type(SchemaValueType.Object)
				.Defs(
					(nameof(JustFoo), new JsonSchemaBuilder()
						.Type(SchemaValueType.Object)
						.Properties(
							(nameof(IFoo.FooValue), new JsonSchemaBuilder().Type(SchemaValueType.Integer))
						)
					)
				)
				.Properties(
					(nameof(TwoJustFoosOneWithAttributes.JustFoo1), new JsonSchemaBuilder().Ref("#/$defs/JustFoo")),
					(nameof(TwoJustFoosOneWithAttributes.JustFoo2), new JsonSchemaBuilder()
						.Ref("#/$defs/JustFoo")
						.ReadOnly(true)
					)
				)
				.Build();

			var actual = new JsonSchemaBuilder().FromType<TwoJustFoosOneWithAttributes>().Build();

			AssertEqual(expected, actual);
		}

		private class NoProps : INoProps
		{
			public int Method() => throw new NotImplementedException();
		}

		private class OtherNoPropsImpl : INoProps
		{
			public int SelfDefinedValue { get; set; }

			public int Method() => throw new NotImplementedException();
		}

		private class NoInheritedPropsTestTarget
		{
			public NoProps NoProps { get; set; }
			public OtherNoPropsImpl OtherNoPropsImpl { get; set; }
		}

		[Test]
		public void InterfacesAreNotExtractedIfNoPropertiesDefined()
		{
			var expected = new JsonSchemaBuilder()
				.Type(SchemaValueType.Object)
				.Properties(
					(nameof(NoInheritedPropsTestTarget.NoProps), new JsonSchemaBuilder()
						.Type(SchemaValueType.Object)
					),
					(nameof(NoInheritedPropsTestTarget.OtherNoPropsImpl), new JsonSchemaBuilder()
						.Type(SchemaValueType.Object)
						.Properties(
							(nameof(OtherNoPropsImpl.SelfDefinedValue), new JsonSchemaBuilder().Type(SchemaValueType.Integer))
						)
					)
				)
				.Build();

			var actual = new JsonSchemaBuilder().FromType<NoInheritedPropsTestTarget>().Build();

			AssertEqual(expected, actual);
		}
	}
}
