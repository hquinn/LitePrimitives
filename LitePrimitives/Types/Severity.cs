// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
/// An enum representing the severity of an error.
/// </summary>
public enum Severity
{
    /// <summary>
    /// Critical severity. This is the highest severity level which can cause an application to crash.
    /// </summary>
    Critical = 1,
    
    /// <summary>
    /// Error severity. This is a high severity level which can cause an operation to fail.
    /// </summary>
    Error = 2,
    
    /// <summary>
    /// Warning severity. This is a medium severity level which can cause an operation to have unexpected results.
    /// </summary>
    Warning = 3,
}