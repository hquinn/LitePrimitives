namespace LitePrimitives.UnitTests.ErrorTypes;

public class FaultTests
{
    [Fact]
    public void Correctly_Sets_Properties_When_Constructing_Fault_Error()
    {
        var sut = new Fault
        {
            Title = ErrorConstants.Title,
            Description = ErrorConstants.Description,
            Code = ErrorConstants.Code,
            HelpLink = ErrorConstants.HelpLink,
            Exception = ErrorConstants.Exception,
        };
        
        sut.ShouldBeenCreatedWith(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            Severity.Fault,
            ErrorConstants.Exception);
    }
    
    [Fact]
    public void Correctly_Sets_Properties_When_Constructing_Fault_Error_With_Constructor()
    {
        var sut = new Fault(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.Exception, 
            ErrorConstants.HelpLink);
        
        sut.ShouldBeenCreatedWith(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            Severity.Fault,
            ErrorConstants.Exception);
    }
}