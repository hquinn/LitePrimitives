namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class OnFailureAsyncTests
{
    [Fact]
    public async Task Performs_Action_When_Result_Parameter_Is_In_The_Failure_State()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = await sut.OnFailureAsync(errors => Task.FromResult(actual = errors.First().Title));

        using var _ = new AssertionScope();
        actual.Should().Be(ErrorConstants.Title);
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Result_Task_Parameter_Is_In_The_Failure_State()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError()).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnFailureAsync(errors => Task.FromResult(actual = errors.First().Title));

        using var _ = new AssertionScope();
        actual.Should().Be(ErrorConstants.Title);
        result.Should().Be(awaitedSut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Result_Parameter_Is_In_The_Failure_State_Unit_Override()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = await sut.OnFailureAsync(errors =>
        {
            actual = errors.First().Title;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().Be(ErrorConstants.Title);
        result.Should().Be(sut);
    }
    
    [Fact]
    public async Task Performs_Action_When_Result_Task_Parameter_Is_In_The_Failure_State_Unit_Override()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError()).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnFailureAsync(errors =>
        {
            actual = errors.First().Title;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().Be(ErrorConstants.Title);
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Parameter_Is_In_The_Success_State()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = await sut.OnFailureAsync(errors => Task.FromResult(actual = errors.First().Title));

        using var _ = new AssertionScope();
        actual.Should().BeEmpty();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Task_Parameter_Is_In_The_Success_State()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnFailureAsync(errors => Task.FromResult(actual = errors.First().Title));

        using var _ = new AssertionScope();
        actual.Should().BeEmpty();
        result.Should().Be(awaitedSut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Parameter_Is_In_The_Success_State_Unit_Override()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = await sut.OnFailureAsync(errors =>
        {
            actual = errors.First().Title;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeEmpty();
        result.Should().Be(sut);
    }

    [Fact]
    public async Task Only_Returns_Result_When_Result_Task_Parameter_Is_In_The_Success_State_Unit_Override()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse).ToTask();
        var awaitedSut = await sut;

        var result = await sut.OnFailureAsync(errors =>
        {
            actual = errors.First().Title;
            return Task.FromResult(Unit.Default);
        });

        using var _ = new AssertionScope();
        actual.Should().BeEmpty();
        result.Should().Be(awaitedSut);
    }
}