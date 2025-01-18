using System.Collections.ObjectModel;

// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Represents an error that can occur within the application.
/// </summary>
public readonly struct Error
{
    private Error(
        string code,
        string message,
        ErrorType errorType,
        ReadOnlyDictionary<string, object?>? metadata)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
        Metadata = metadata;
    }

    /// <summary>
    ///     The unique code of the error.
    /// </summary>
    public string Code { get; }

    /// <summary>
    ///     The message describing the error.
    /// </summary>
    public string Message { get; }

    /// <summary>
    ///     The type of the error, indicating the category or nature of the failure.
    /// </summary>
    public ErrorType ErrorType { get; }

    /// <summary>
    ///     Additional contextual information about the error.
    ///     This dictionary may be null or empty if no extra data is associated with the error.
    /// </summary>
    public IDictionary<string, object?>? Metadata { get; }

    /// <summary>
    ///     Creates a new <see cref="Error"/> instance without metadata.
    /// </summary>
    /// <param name="code">A unique string code identifying the error.</param>
    /// <param name="message">A descriptive message explaining the error.</param>
    /// <param name="errorType">The <see cref="ErrorType"/> categorizing the nature of the error.</param>
    /// <returns>A new <see cref="Error"/> instance.</returns>
    public static Error Create(
        string code,
        string message,
        ErrorType errorType)
    {
        return new Error(code, message, errorType, null);
    }

    /// <summary>
    ///     Creates a new <see cref="Error"/> instance with the provided metadata.
    /// </summary>
    /// <param name="code">A unique string code identifying the error.</param>
    /// <param name="message">A descriptive message explaining the error.</param>
    /// <param name="errorType">The <see cref="ErrorType"/> categorizing the nature of the error.</param>
    /// <param name="metadata">
    ///     A dictionary of key/value pairs providing additional context about the error.
    ///     The dictionary will be converted to a read-only structure for immutability.
    /// </param>
    /// <returns>A new <see cref="Error"/> instance.</returns>
    public static Error Create(
        string code,
        string message,
        ErrorType errorType,
        IDictionary<string, object?>? metadata)
    {
        var readOnlyMetadata = metadata == null 
            ? null 
            : new ReadOnlyDictionary<string, object?>(metadata);
        return new Error(code, message, errorType, readOnlyMetadata);
    }

    /// <summary>
    ///     Creates a Failure error for the context when <see cref="Option{TValue}"/> is None.
    /// </summary>
    public static Error IsNone()
    {
        return Create("IsNone", "The Option is None", ErrorType.Failure);
    }

    /// <summary>
    ///     Creates a Failure error without metadata.
    /// </summary>
    public static Error Failure(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Failure);
    }

    /// <summary>
    ///     Creates a Failure error with metadata.
    /// </summary>
    public static Error Failure(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Failure, metadata);
    }

    /// <summary>
    ///     Creates a Validation error without metadata.
    /// </summary>
    public static Error Validation(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Validation);
    }

    /// <summary>
    ///     Creates a Validation error with metadata.
    /// </summary>
    public static Error Validation(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Validation, metadata);
    }

    /// <summary>
    ///     Creates a BadRequest error without metadata.
    /// </summary>
    public static Error BadRequest(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.BadRequest);
    }

    /// <summary>
    ///     Creates a BadRequest error with metadata.
    /// </summary>
    public static Error BadRequest(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.BadRequest, metadata);
    }

    /// <summary>
    ///     Creates a NotFound error without metadata.
    /// </summary>
    public static Error NotFound(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.NotFound);
    }

    /// <summary>
    ///     Creates a NotFound error with metadata.
    /// </summary>
    public static Error NotFound(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.NotFound, metadata);
    }

    /// <summary>
    ///     Creates a Conflict error without metadata.
    /// </summary>
    public static Error Conflict(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Conflict);
    }

    /// <summary>
    ///     Creates a Conflict error with metadata.
    /// </summary>
    public static Error Conflict(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Conflict, metadata);
    }

    /// <summary>
    ///     Creates an Unauthorized error without metadata.
    /// </summary>
    public static Error Unauthorized(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Unauthorized);
    }

    /// <summary>
    ///     Creates an Unauthorized error with metadata.
    /// </summary>
    public static Error Unauthorized(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Unauthorized, metadata);
    }

    /// <summary>
    ///     Creates a Forbidden error without metadata.
    /// </summary>
    public static Error Forbidden(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Forbidden);
    }

    /// <summary>
    ///     Creates a Forbidden error with metadata.
    /// </summary>
    public static Error Forbidden(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Forbidden, metadata);
    }

    /// <summary>
    ///     Creates a ServiceUnavailable error without metadata.
    /// </summary>
    public static Error ServiceUnavailable(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.ServiceUnavailable);
    }

    /// <summary>
    ///     Creates a ServiceUnavailable error with metadata.
    /// </summary>
    public static Error ServiceUnavailable(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.ServiceUnavailable, metadata);
    }

    /// <summary>
    ///     Creates a Timeout error without metadata.
    /// </summary>
    public static Error Timeout(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Timeout);
    }

    /// <summary>
    ///     Creates a Timeout error with metadata.
    /// </summary>
    public static Error Timeout(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Timeout, metadata);
    }

    /// <summary>
    ///     Creates an IoError error without metadata.
    /// </summary>
    public static Error IoError(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.IoError);
    }

    /// <summary>
    ///     Creates an IoError error with metadata.
    /// </summary>
    public static Error IoError(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.IoError, metadata);
    }

    /// <summary>
    ///     Creates a Deprecated error without metadata.
    /// </summary>
    public static Error Deprecated(
        string code,
        string message)
    {
        return Create(code, message, ErrorType.Deprecated);
    }

    /// <summary>
    ///     Creates a Deprecated error with metadata.
    /// </summary>
    public static Error Deprecated(
        string code,
        string message,
        IDictionary<string, object?> metadata)
    {
        return Create(code, message, ErrorType.Deprecated, metadata);
    }

    /// <summary>
    ///     Creates an Aggregate error with metadata.
    /// </summary>
    public static Error Aggregate(IEnumerable<Error> errors)
    {
        var metaData = new Dictionary<string, object?>();

        var counter = 1;
        foreach (var error in errors)
        {
            metaData.Add($"Error {counter++}", error);
        }
        
        return Create(
            "AggregateError", 
            $"This error has aggregated {metaData.Count} other errors.", 
            ErrorType.Aggregate, 
            metaData);
    }
}