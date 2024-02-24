namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class MapTests
{
    [Fact]
    public void Returns_Mapped_Value_When_Option_Parameter_Is_In_The_Some_State()
    {
        const bool expected = OptionConstants.FirstValue;
        var sut = Option<int>.Some(OptionConstants.SecondValue);

        var actual = sut.Map(_ => OptionConstants.FirstValue);

        actual.ShouldReturnValueOnMatch(expected);
    }

    [Fact]
    public void Returns_Nothing_When_Option_Parameter_Is_In_The_None_State()
    {
        var sut = Option<int>.None();

        var actual = sut.Map(_ => OptionConstants.FirstValue);

        actual.ShouldReturnNothingOnMatch();
    }
}