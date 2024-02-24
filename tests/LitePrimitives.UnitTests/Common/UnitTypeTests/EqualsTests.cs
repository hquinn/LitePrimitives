namespace LitePrimitives.UnitTests.Common.UnitTypeTests;

public class EqualsTests
{
    [Fact]
    public void Returns_True_When_Compared_To_Another_Unit()
    {
        Unit.Default.Equals(Unit.Default).Should().BeTrue();
    }
    
    [Fact]
    public void Returns_True_When_Object_Is_Unit()
    {
        object unit = Unit.Default;
        Unit.Default.Equals(unit).Should().BeTrue();
    }
    
    [Fact]
    public void Returns_False_When_Comparing_To_Null()
    {
        Unit.Default.Equals(null).Should().BeFalse();
    }
    
    [Fact]
    public void Returns_False_When_Comparing_To_Another_Object()
    {
        // ReSharper disable once SuspiciousTypeConversion.Global
        Unit.Default.Equals(true).Should().BeFalse();
    }
}