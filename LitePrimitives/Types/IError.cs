// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
/// Contract for an error type.
/// </summary>
public interface IError
{
    /// <summary>
    /// The unique code of the error.
    /// </summary>
    string Code { get; }
    
    /// <summary>
    /// The message of the error.
    /// </summary>
    string Message { get; }
    
    /// <summary>
    /// The metadata of the error.
    /// </summary>
    Dictionary<string, object> Metadata { get; }
}