namespace LitePrimitives;

/// <summary>
/// Contract for an error type.
/// </summary>
public interface IError
{
    /// <summary>
    /// The message of the error.
    /// </summary>
    string Message { get; }
}