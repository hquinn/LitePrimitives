using LitePrimitives.UnitTests.Helpers.Fakes;

namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class BindTests
{
    private readonly FakeBind _sut = new();

    [Fact]
    public void Returns_Errors_When_Result_Parameter_Is_In_The_Failure_State()
    {
        var expected = ErrorFactory.CreateError();
        var parameter = Result<int>.Failure(expected);

        var actual = parameter.Bind(_sut.TestResultFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(0);
        actual.ShouldReturnErrorOnMatch(expected);
    }

    [Fact]
    public void Returns_Bind_Response_When_Result_Parameter_Is_In_The_Success_State()
    {
        const bool expected = ResultConstants.FirstResponse;
        var parameter = Result<int>.Success(ResultConstants.SecondResponse);

        var actual = parameter.Bind(_sut.TestResultFunc);

        using var _ = new AssertionScope();
        _sut.TimesCalled.Should().Be(1);
        actual.ShouldReturnResponseOnMatch(expected);
    }
}