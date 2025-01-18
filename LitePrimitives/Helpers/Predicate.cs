namespace LitePrimitives.Helpers;

internal static class Predicate
{
    // https://github.com/dotnet/dotNext/blob/master/src/DotNext/Predicate.cs
    internal static Predicate<T> Constant<T>(bool value)
    {
        return value ? True : False;
        
        static bool True(T value) => true;

        static bool False(T value) => false;
    }
}