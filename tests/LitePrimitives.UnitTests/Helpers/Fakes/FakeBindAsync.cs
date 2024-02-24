namespace LitePrimitives.UnitTests.Helpers.Fakes;

public class FakeBindAsync
{
    public int TimesCalled { get; private set; }

    public Task<Result<bool>> TestResultFunc(int parameter)
    {
        TimesCalled++;
        return Result<bool>.Success(true).ToTask();
    }

    public Task<Option<bool>> TestOptionFunc(int parameter)
    {
        TimesCalled++;
        return Option<bool>.Some(true).ToTask();
    }

    public Task<Either<bool, bool>> TestLeftEitherFunc(int parameter)
    {
        TimesCalled++;
        return Either<bool, bool>.Left(true).ToTask();
    }

    public Task<Either<bool, bool>> TestRightEitherFunc(int parameter)
    {
        TimesCalled++;
        return Either<bool, bool>.Right(true).ToTask();
    }
}