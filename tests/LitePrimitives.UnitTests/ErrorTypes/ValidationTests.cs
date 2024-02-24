namespace LitePrimitives.UnitTests.ErrorTypes;

public class ValidationTests
{
    [Fact]
    public void Correctly_Sets_Properties_When_Constructing_Validation_Error()
    {
        var sut = new Validation
        {
            Title = ErrorConstants.Title,
            Description = ErrorConstants.Description,
            Code = ErrorConstants.Code,
            HelpLink = ErrorConstants.HelpLink,
            Context = ErrorConstants.Context,
            Severity = ErrorConstants.Severity,
            PropertyName = ErrorConstants.PropertyName,
            PropertyPath = ErrorConstants.PropertyPath,
            AttemptedValue = ErrorConstants.AttemptedValue,
        };
        
        sut.ShouldBeenCreatedWith(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            ErrorConstants.Context,
            ErrorConstants.Severity,
            ErrorConstants.PropertyName,
            ErrorConstants.PropertyPath,
            ErrorConstants.AttemptedValue);
    }
    
    [Fact]
    public void Correctly_Sets_Properties_When_Constructing_Validation_Error_With_Constructor()
    {
        var sut = new Validation(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.PropertyName,
            ErrorConstants.PropertyPath,
            ErrorConstants.AttemptedValue,
            ErrorConstants.Context,
            ErrorConstants.HelpLink,
            ErrorConstants.Severity);
        
        sut.ShouldBeenCreatedWith(
            ErrorConstants.Title,
            ErrorConstants.Description,
            ErrorConstants.Code,
            ErrorConstants.HelpLink,
            ErrorConstants.Context,
            ErrorConstants.Severity,
            ErrorConstants.PropertyName,
            ErrorConstants.PropertyPath,
            ErrorConstants.AttemptedValue);
    }
}