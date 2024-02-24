namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class OnSuccessAsyncTests
{
    [Fact]
    public async Task Performs_Action_When_Result_Parameter_Is_In_The_Success_State()
    {
        var actual = false;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = await sut.OnSuccessAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Result_Task_Parameter_Is_In_The_Success_State()
    {
        var actual = false;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnSuccessAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(awaitedSut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Result_Parameter_Is_In_The_Success_State_Unit_Override()
    {
        var actual = false;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = await sut.OnSuccessAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Result_Task_Parameter_Is_In_The_Success_State_Unit_Override()
    {
        var actual = false;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnSuccessAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Parameter_Is_In_The_Failure_State()
    {
        var actual = false;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = await sut.OnSuccessAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Task_Parameter_Is_In_The_Failure_State()
    {
        var actual = false;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError()).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnSuccessAsync(response => Task.FromResult(actual = response));

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Parameter_Is_In_The_Failure_State_Unit_Override()
    {
        var actual = false;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = await sut.OnSuccessAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Task_Parameter_Is_In_The_Failure_State_Unit_Override()
    {
        var actual = false;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError()).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnSuccessAsync(response =>
        {
            actual = response;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(awaitedSut);
    }
}