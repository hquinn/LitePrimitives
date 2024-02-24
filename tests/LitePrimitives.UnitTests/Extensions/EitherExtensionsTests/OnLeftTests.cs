namespace LitePrimitives.UnitTests.Extensions.EitherExtensionsTests;

public class OnLeftTests
{
    [Fact]
    public void Performs_Action_When_Either_Parameter_Is_In_The_Left_State()
    {
        var actual = false;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var result = sut.OnLeft(response => actual = response);

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }
    
    [Fact]
    public void Performs_Action_When_Either_Parameter_Is_In_The_Left_State_Unit_Override()
    {
        var actual = false;
        var sut = Either<bool, bool>.Left(EitherConstants.SecondLeftValue);

        var result = sut.OnLeft(response =>
        {
            actual = response;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeTrue();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Either_When_Either_Parameter_Is_In_The_Right_State()
    {
        var actual = false;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var result = sut.OnLeft(response => actual = response);

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }

    [Fact]
    public void Only_Returns_Either_When_Either_Parameter_Is_In_The_Right_State_Unit_Override()
    {
        var actual = false;
        var sut = Either<bool, bool>.Right(EitherConstants.SecondRightValue);

        var result = sut.OnLeft(response =>
        {
            actual = response;
            return Unit.Default;
        });

        using var _ = new AssertionScope();
        actual.Should().BeFalse();
        result.Should().Be(sut);
    }
}