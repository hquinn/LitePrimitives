namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class MapRightAsyncTests
{
    [Fact]
    public async Task Returns_Mapped_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const int expected = EitherConstants.FirstRightValue;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var actual = await sut.MapRightAsync(_ => Task.FromResult(EitherConstants.FirstRightValue));

        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }
    
    [Fact]
    public async Task Returns_Mapped_Right_Value_When_Either_Task_Parameter_Is_In_The_Right_State()
    {
        const int expected = EitherConstants.FirstRightValue;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue).ToTask();

        var actual = await sut.MapRightAsync(_ => Task.FromResult(EitherConstants.FirstRightValue));

        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var actual = await sut.MapRightAsync(_ => Task.FromResult(EitherConstants.FirstRightValue));

        await actual.ShouldReturnLeftValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Left_Value_When_Either_Task_Parameter_Is_In_The_Left_State()
    {
        const bool expected = EitherConstants.SecondLeftValue;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue).ToTask();

        var actual = await sut.MapRightAsync(_ => Task.FromResult(EitherConstants.FirstRightValue));

        await actual.ShouldReturnLeftValueOnMatchAsync(expected);
    }
}