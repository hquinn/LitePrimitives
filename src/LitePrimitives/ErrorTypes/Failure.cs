using System.Diagnostics.CodeAnalysis;

namespace LitePrimitives;

/// <summary>
///     Represents the standard error type.
/// </summary>
public readonly record struct Failure : IError
{
    /// <summary>
    ///     Parameterless constructor, to be used with the object initialization syntax.
    /// </summary>
    public Failure()
    {
    }
    
    /// <summary>
    ///     Constructor which sets all required fields.
    /// </summary>
    [SetsRequiredMembers]
    public Failure(
        string title, 
        string description, 
        string code,
        Severity severity = Severity.Error)
    {
        Title = title;
        Description = description;
        Code = code;
        Severity = severity;
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
    public required Severity Severity { get; init; }
}