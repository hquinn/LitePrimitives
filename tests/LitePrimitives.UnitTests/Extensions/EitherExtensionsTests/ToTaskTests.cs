namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class ToTaskTests
{
    [Fact]
    public async Task Returns_Task_Of_Either()
    {
        const int expected = EitherConstants.ExpectedRightValue;

        var sut = Either<bool, int>.Right(expected).ToTask();
        var actual = await sut;
        
        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }
}