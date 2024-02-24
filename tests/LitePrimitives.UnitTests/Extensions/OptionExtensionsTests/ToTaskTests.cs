namespace LitePrimitives.UnitTests.Extensions.OptionExtensionsTests;

public class ToTaskTests
{
    [Fact]
    public async Task Returns_Task_Of_Option()
    {
        const bool expected = OptionConstants.ExpectedValue;

        var sut = Option<bool>.Some(expected).ToTask();
        var actual = await sut;

        await actual.ShouldReturnValueOnMatchAsync(expected);
    }
}