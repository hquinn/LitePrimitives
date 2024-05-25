// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Represents a type that contains no value. To be used instead of void.
/// </summary>
public readonly struct Unit : IEquatable<Unit>, IComparable<Unit>
{
    /// <summary>
    ///     The default value of a Unit.
    /// </summary>
    public static readonly Unit Default = new();

    /// <summary>
    ///     <inheritdoc /> 
    /// </summary>
    public int CompareTo(Unit other)
    {
        return 0;
    }

    /// <summary>
    ///     <inheritdoc /> 
    /// </summary>
    public bool Equals(Unit other)
    {
        return true;
    }

    /// <summary>
    ///     <inheritdoc /> 
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is Unit;
    }

    /// <summary>
    ///     <inheritdoc /> 
    /// </summary>
    public override int GetHashCode()
    {
        return 0;
    }

    /// <summary>
    ///     The equals operator which returns true when comparing two Unit types, otherwise false.
    /// </summary>
    /// <param name="left">The left hand-side Unit type used for the comparison.</param>
    /// <param name="right">The right hand-side Unit type used for the comparison.</param>
    /// <returns>Returns true when comparing two Unit types, otherwise false.</returns>
    public static bool operator ==(Unit left, Unit right)
    {
        return true;
    }

    /// <summary>
    ///     The not equals operator which returns false when comparing two Unit types, otherwise true.
    /// </summary>
    /// <param name="left">The left hand-side Unit type used for the comparison.</param>
    /// <param name="right">The right hand-side Unit type used for the comparison.</param>
    /// <returns>Returns true when comparing two Unit types, otherwise false.</returns>
    public static bool operator !=(Unit left, Unit right)
    {
        return false;
    }
}