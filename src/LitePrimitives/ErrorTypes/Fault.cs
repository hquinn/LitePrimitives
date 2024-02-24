using System.Diagnostics.CodeAnalysis;

namespace LitePrimitives;

/// <summary>
///     Represents a Fault.
/// </summary>
public readonly record struct Fault : IError
{
    public Fault()
    {
    }
    
    [SetsRequiredMembers]
    public Fault(
        string title, 
        string description, 
        string code, 
        Exception exception)
    {
        Title = title;
        Description = description;
        Code = code;
        Exception = exception;
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
    ///     Represents the Severity of the Error. This will be set to Fault.
    /// </summary>
    public Severity Severity
    {
        get { return Severity.Fault; }
    }

    /// <summary>
    ///     Represents the Exception of the Error.
    /// </summary>
    public required Exception Exception { get; init; }
}