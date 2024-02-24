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

    public int CompareTo(Unit other)
    {
        return 0;
    }

    public bool Equals(Unit other)
    {
        return true;
    }

    public override bool Equals(object? obj)
    {
        return obj is Unit;
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public static bool operator ==(Unit left, Unit right)
    {
        return true;
    }

    public static bool operator !=(Unit left, Unit right)
    {
        return false;
    }
}