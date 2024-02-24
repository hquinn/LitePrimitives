namespace LitePrimitives.UnitTests.Helpers.Factories;

public static class ErrorFactory
{
    public static IError CreateError() =>
        new Failure(ErrorConstants.Title, ErrorConstants.Description, ErrorConstants.Code);
}