using System.Diagnostics.CodeAnalysis;

namespace LitePrimitives;

/// <summary>
///     Represents an error type where exceptional errors occur.
/// </summary>
public readonly record struct Fault : IError
{
    /// <summary>
    ///     Parameterless constructor, to be used with the object initialization syntax.
    /// </summary>
    public Fault()
    {
    }
    
    /// <summary>
    ///     Constructor which sets all required fields.
    /// </summary>
    [SetsRequiredMembers]
    public Fault(
        string title, 
        string description, 
        string code,
        Exception exception,
        string? helpLink = null)
    {
        Title = title;
        Description = description;
        Code = code;
        Exception = exception;
        HelpLink = helpLink;
    }
    
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public required string Title { get; init; }
    
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public required string Description { get; init; }
    
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    public required string? HelpLink { get; init; } = null;

    /// <summary>
    ///     Represents the Severity of the Error. This will be set to Fault.
    /// </summary>
    public Severity Severity => Severity.Fault;

    /// <summary>
    ///     Represents the Exception of the Error.
    /// </summary>
    public required Exception Exception { get; init; }
}