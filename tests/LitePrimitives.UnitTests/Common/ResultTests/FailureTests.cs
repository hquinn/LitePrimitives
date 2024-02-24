namespace LitePrimitives.UnitTests.Common.ResultTests;

public class FailureTests
{
    private readonly IFixture _fixture = FixtureFactory.CreateFixture();
    
    [Fact]
    public void Returns_Result_From_Error()
    {
        var expected = _fixture.Create<IError>();

        Result<int>.Failure(expected).ShouldReturnErrorOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Result_From_Array_Of_Errors()
    {
        var expected = _fixture.CreateMany<IError>().ToArray();
    
        Result<int>.Failure(expected).ShouldReturnArrayOfErrorOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Result_From_List_Of_Errors()
    {
        var expected = _fixture.CreateMany<IError>().ToList();
    
        Result<int>.Failure(expected).ShouldReturnArrayOfErrorOnMatch(expected);
    }
}