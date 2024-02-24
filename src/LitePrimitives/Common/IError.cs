namespace LitePrimitives;

/// <summary>
///     Represents the minimal contract for an Error.
/// </summary>
public interface IError
{
    /// <summary>
    ///     Represents the Title of the Error. Usually a short description of the Error.
    /// </summary>
    public string Title { get; }

    /// <summary>
    ///     Represents the Description of the Error. Usually a long description of the Error.
    /// </summary>
    public string Description { get; }
	
    /// <summary>
    ///     Represents the Code of the Error. Helps uniquely identify the Error.
    /// </summary>
    public string Code { get; }
    
    /// <summary>
    ///     Represents the Severity of the Error. Usually will be set to Error.
    /// </summary>
    public Severity Severity { get; }
}