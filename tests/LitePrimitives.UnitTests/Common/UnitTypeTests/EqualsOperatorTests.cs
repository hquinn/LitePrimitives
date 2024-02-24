namespace LitePrimitives.UnitTests.Common.UnitTypeTests;

public class EqualsOperatorTests
{
    [Fact]
    public void Returns_True_When_Compared_To_Another_Unit()
    {
        var first = Unit.Default;
        var second = Unit.Default;
        (first == second).Should().BeTrue();
    }
    
    [Fact]
    public void Returns_True_When_Object_Is_Unit()
    {
        object unit = Unit.Default;
        (Unit.Default == (Unit)unit).Should().BeTrue();
    }
    
    [Fact]
    public void Returns_False_When_Comparing_To_Null()
    {
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
        // ReSharper disable once RedundantCast
        (Unit.Default == (Unit?)null).Should().BeFalse();
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
    }
}