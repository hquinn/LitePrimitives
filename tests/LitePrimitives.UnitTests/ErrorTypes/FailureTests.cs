namespace LitePrimitives.UnitTests.ErrorTypes;

public class FailureTests
{
    [Fact]
    public void Correctly_Sets_Properties_When_Constructing_Failure_Error()
    {
        var sut = new Failure
        {
            Title = ErrorConstants.Title,
            Description = ErrorConstants.Description,
            Code = ErrorConstants.Code,
            HelpLink = ErrorConstants.HelpLink,
            Severity = ErrorConstants.Severity,
        };
        
        sut.ShouldBeenCreatedWith(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            ErrorConstants.Severity);
    }
    
    [Fact]
    public void Correctly_Sets_Properties_When_Constructing_Failure_Error_With_Constructor()
    {
        var sut = new Failure(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            ErrorConstants.Severity);
        
        sut.ShouldBeenCreatedWith(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            ErrorConstants.Severity);
    }
}