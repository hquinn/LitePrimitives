namespace LitePrimitives.UnitTests.Helpers.Constants;

public static class ErrorConstants
{
    public const string Title = "Title";
    public const string Description = "Description";
    public const string Code = "Code";
    public const Severity Severity = LitePrimitives.Severity.Info;
    public const string PropertyName = "Foo";
    public const string PropertyPath = "Foo";
    public const string AttemptedValue = "Bar";
    public static readonly Exception Exception = new("Test");
}