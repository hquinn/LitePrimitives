using System.Diagnostics.CodeAnalysis;

namespace LitePrimitives;

/// <summary>
///     Represents a Validation Error.
/// </summary>
public readonly record struct Validation : IError
{
    public Validation()
    {
    }
    
    [SetsRequiredMembers]
    public Validation(
        string title, 
        string description, 
        string code, 
        string propertyName,
        string propertyPath,
        object? attemptedValue,
        Severity severity = Severity.Error)
    {
        Title = title;
        Description = description;
        Code = code;
        PropertyName = propertyName;
        PropertyPath = propertyPath;
        AttemptedValue = attemptedValue;
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
    public required Severity Severity { get; init; } = Severity.Error;
    
    /// <summary>
    ///     Represents the PropertyName of the Error.
    /// </summary>
    public required string PropertyName { get; init; }
    
    /// <summary>
    ///     Represents the PropertyPath of the Error.
    ///     If the Property is nested, this will be the full path to the Property.
    /// </summary>
    public required string PropertyPath { get; init; }
    
    /// <summary>
    ///     Represents the AttemptedValue of the Error.
    /// </summary>
    public required object? AttemptedValue { get; init; }
}