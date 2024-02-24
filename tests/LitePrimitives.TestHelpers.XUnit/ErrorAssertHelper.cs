using FluentAssertions;
using FluentAssertions.Execution;

namespace LitePrimitives.TestHelpers.XUnit;

public static class ErrorAssertHelper
{
    public static void ShouldBeenCreatedWith(
        this Validation actualError,
        string expectedTitle,
        string expectedDescription,
        string expectedCode,
        string expectedHelpLink,
        IDictionary<string, object?> context,
        Severity expectedSeverity,
        string expectedPropertyName,
        string expectedPropertyPath,
        string expectedAttemptedValue)
    {
        using var _ = new AssertionScope();
        
        actualError.Title.Should().Be(expectedTitle);
        actualError.Description.Should().Be(expectedDescription);
        actualError.Code.Should().Be(expectedCode);
        actualError.HelpLink.Should().Be(expectedHelpLink);
        actualError.Context.Should().BeEquivalentTo(context);
        actualError.Severity.Should().Be(expectedSeverity);
        actualError.PropertyName.Should().Be(expectedPropertyName);
        actualError.PropertyPath.Should().Be(expectedPropertyPath);
        actualError.AttemptedValue.Should().Be(expectedAttemptedValue);
    }
    
    public static void ShouldBeenCreatedWith(
        this Failure actualError,
        string expectedTitle,
        string expectedDescription,
        string expectedCode,
        string expectedHelpLink,
        Severity expectedSeverity)
    {
        using var _ = new AssertionScope();
        
        actualError.Title.Should().Be(expectedTitle);
        actualError.Description.Should().Be(expectedDescription);
        actualError.Code.Should().Be(expectedCode);
        actualError.HelpLink.Should().Be(expectedHelpLink);
        actualError.Severity.Should().Be(expectedSeverity);
    }
    
    public static void ShouldBeenCreatedWith(
        this Fault actualError,
        string expectedTitle,
        string expectedDescription,
        string expectedCode,
        string expectedHelpLink,
        Severity expectedSeverity,
        Exception expectedException)
    {
        using var _ = new AssertionScope();
        
        actualError.Title.Should().Be(expectedTitle);
        actualError.Description.Should().Be(expectedDescription);
        actualError.Code.Should().Be(expectedCode);
        actualError.HelpLink.Should().Be(expectedHelpLink);
        actualError.Severity.Should().Be(expectedSeverity);
        actualError.Exception.Should().BeEquivalentTo(expectedException);
    }
}