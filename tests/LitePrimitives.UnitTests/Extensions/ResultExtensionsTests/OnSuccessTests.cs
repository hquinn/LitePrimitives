namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class OnSuccessTests
{
    [Fact]
    public void Performs_Action_When_Result_Parameter_Is_In_The_Success_State()
    {
        var actual = false;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = sut.OnSuccess(response => actual = response);

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public void Performs_Action_When_Result_Parameter_Is_In_The_Success_State_Unit_Override()
    {
        var actual = false;
        var sut = Result<bool>.Success(ResultConstants.ExpectedResponse);

        var result = sut.OnSuccess(response =>
        {
            actual = response;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Result_When_Result_Parameter_Is_In_The_Failure_State()
    {
        var actual = false;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = sut.OnSuccess(response => actual = response);

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Result_When_Result_Parameter_Is_In_The_Failure_State_Unit_Override()
    {
        var actual = false;
        var sut = Result<bool>.Failure(ErrorFactory.CreateError());

        var result = sut.OnSuccess(response =>
        {
            actual = response;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }
}