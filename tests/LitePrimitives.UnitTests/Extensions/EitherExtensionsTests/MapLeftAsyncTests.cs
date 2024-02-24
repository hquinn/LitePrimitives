namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class MapLeftAsyncTests
{
    [Fact]
    public async Task Returns_Mapped_Left_Value_When_Either_Parameter_Is_In_The_Left_State()
    {
        const int expected = EitherConstants.FirstLeftValue;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var actual = await sut.MapLeftAsync(_ => Task.FromResult(EitherConstants.FirstLeftValue));

        await actual.ShouldReturnLeftValueOnMatchAsync(expected);
    }
    
    [Fact]
    public async Task Returns_Mapped_Left_Value_When_Either_Task_Parameter_Is_In_The_Left_State()
    {
        const int expected = EitherConstants.FirstLeftValue;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue).ToTask();

        var actual = await sut.MapLeftAsync(_ => Task.FromResult(EitherConstants.FirstLeftValue));

        await actual.ShouldReturnLeftValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Right_Value_When_Either_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var actual = await sut.MapLeftAsync(_ => Task.FromResult(EitherConstants.FirstLeftValue));

        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }

    [Fact]
    public async Task Returns_Right_Value_When_Either_Task_Parameter_Is_In_The_Right_State()
    {
        const bool expected = EitherConstants.SecondRightValue;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue).ToTask();

        var actual = await sut.MapLeftAsync(_ => Task.FromResult(EitherConstants.FirstLeftValue));

        await actual.ShouldReturnRightValueOnMatchAsync(expected);
    }
}