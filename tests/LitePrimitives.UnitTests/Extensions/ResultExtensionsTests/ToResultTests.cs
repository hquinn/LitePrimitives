namespace LitePrimitives.UnitTests.Extensions.ResultExtensionsTests;

public class ToResultTests
{
    private readonly IFixture _fixture = FixtureFactory.CreateFixture();

    [Fact]
    public void Returns_Result_From_Response()
    {
        const bool expected = ResultConstants.ExpectedResponse;

        expected.ToResult().ShouldReturnResponseOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Result_From_Error()
    {
        var expected = _fixture.Create<IError>();

        expected.ToResult<int>().ShouldReturnErrorOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Result_From_Array_Of_Errors()
    {
        var expected = _fixture.CreateMany<IError>().ToArray();
    
        expected.ToResult<int>().ShouldReturnArrayOfErrorOnMatch(expected);
    }
    
    [Fact]
    public void Returns_Result_From_List_Of_Errors()
    {
        var expected = _fixture.CreateMany<IError>().ToList();
    
        expected.ToResult<int>().ShouldReturnArrayOfErrorOnMatch(expected);
    }
}