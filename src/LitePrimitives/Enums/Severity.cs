namespace LitePrimitives;

/// <summary>
///     Used by the <see cref="LitePrimitives.IError"/> to determine the Severity of the error.
/// </summary>
public enum Severity
{
    /// <summary>
    ///     Indicates that the Severity of the error is at Info
    /// </summary>
    Info,
    /// <summary>
    ///     Indicates that the Severity of the error is at Warning
    /// </summary>
    Warning,
    /// <summary>
    ///     Indicates that the Severity of the error is at Error
    /// </summary>
    Error,
    /// <summary>
    ///     Indicates that the Severity of the error is at Fault
    /// </summary>
    Fault,
}