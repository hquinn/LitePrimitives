namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class OnLeftAsyncTests
{
    [Fact]
    public async Task Performs_Action_When_Either_Parameter_Is_In_The_Left_State()
    {
        var actual = false;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var result = await sut.OnLeftAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Either_Task_Parameter_Is_In_The_Left_State()
    {
        var actual = false;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnLeftAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(awaitedSut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Either_Parameter_Is_In_The_Left_State_Unit_Override()
    {
        var actual = false;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var result = await sut.OnLeftAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Either_Task_Parameter_Is_In_The_Left_State_Unit_Override()
    {
        var actual = false;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnLeftAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Either_When_Either_Parameter_Is_In_The_Right_State()
    {
        var actual = false;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var result = await sut.OnLeftAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Either_When_Either_Task_Parameter_Is_In_The_Right_State()
    {
        var actual = false;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnLeftAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Either_When_Either_Parameter_Is_In_The_Right_State_Unit_Override()
    {
        var actual = false;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var result = await sut.OnLeftAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Either_When_Either_Task_Parameter_Is_In_The_Right_State_Unit_Override()
    {
        var actual = false;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnLeftAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(awaitedSut);
    }
}