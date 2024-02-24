namespace LitePrimitives.UnitTests.Helpers.Fakes;

public class FakeBind
{
    public int TimesCalled { get; private set; }

    public Result<bool> TestResultFunc(int parameter)
    {
        TimesCalled++;
        return Result<bool>.Success(true);
    }

    public Option<bool> TestOptionFunc(int parameter)
    {
        TimesCalled++;
        return Option<bool>.Some(true);
    }

    public Either<bool, bool> TestLeftEitherFunc(int parameter)
    {
        TimesCalled++;
        return Either<bool, bool>.Left(true);
    }

    public Either<bool, bool> TestRightEitherFunc(int parameter)
    {
        TimesCalled++;
        return Either<bool, bool>.Right(true);
    }
}