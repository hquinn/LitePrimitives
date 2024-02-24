namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class OnFailureTests
{
    [Fact]
    public void Performs_Action_When_Result_Parameter_Is_In_The_Failure_State()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = sut.OnFailure(errors => actual = errors.First().Title);

        using var _ = new AssertionScope();
        actual.Should().Be(ErrorConstants.Title);
        result.Should().Be(sut);
    }
    
    [Fact]
    public void Performs_Action_When_Result_Parameter_Is_In_The_Failure_State_Unit_Override()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = sut.OnFailure(errors =>
        {
            actual = errors.First().Title;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().Be(ErrorConstants.Title);
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Result_When_Result_Parameter_Is_In_The_Success_State()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = sut.OnFailure(errors => actual = errors.First().Title);

        using var _ = new AssertionScope();
        actual.Should().BeEmpty();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Result_When_Result_Parameter_Is_In_The_Success_State_Unit_Override()
    {
        var actual = string.Empty;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = sut.OnFailure(errors =>
        {
            actual = errors.First().Title;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeEmpty();
        result.Should().Be(sut);
    }
}