// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
/// An enum representing the type of the error.
/// </summary>
public enum ErrorType
{
    /// <summary>
    ///     Traditional failure. Used generally for application-level errors that can occur.
    /// </summary>
    Failure = 1,

    /// <summary>
    ///     When the input data fails validation checks.
    /// </summary>
    Validation = 2,

    /// <summary>
    ///     When the incoming request is malformed.
    /// </summary>
    BadRequest = 3,

    /// <summary>
    ///     When the resource cannot be located.
    /// </summary>
    NotFound = 4,

    /// <summary>
    ///     When there is a conflict with the current state of the resource (e.g., resource already exists).
    /// </summary>
    Conflict = 5,

    /// <summary>
    ///     When authentication credentials are missing or invalid.
    /// </summary>
    Unauthorized = 6,

    /// <summary>
    ///     When the client does not have permission to perform the requested action.
    /// </summary>
    Forbidden = 7,

    /// <summary>
    ///     When the service or a required dependency is temporarily unavailable.
    /// </summary>
    ServiceUnavailable = 9,

    /// <summary>
    ///     When an operation exceeds its time limit.
    /// </summary>
    Timeout = 10,

    /// <summary>
    ///     When an I/O-related error occurs, such as file read/write issues or network-level failures.
    /// </summary>
    IoError = 11,

    /// <summary>
    ///     Indicates the use of a deprecated feature or endpoint.
    /// </summary>
    Deprecated = 12
}