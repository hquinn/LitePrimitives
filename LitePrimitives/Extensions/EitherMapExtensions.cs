// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for Map on the Either type.
/// </summary>
public static class EitherMapExtensions
{
    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputLast>> MapFirstAsync<TInputFirst, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputLast>> MapFirstAsync<TInputFirst, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputLast>> MapLastAsync<TInputFirst, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputLast>> MapLastAsync<TInputFirst, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputSecond, Task<TOutputSecond>> transform)
    {
        var either = await input;

        return await either.MapSecondAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputSecond, TOutputSecond> transform)
    {
        var either = await input;
    
        return either.MapSecond(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputSecond, Task<TOutputSecond>> transform)
    {
        var either = await input;

        return await either.MapSecondAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputSecond, TOutputSecond> transform)
    {
        var either = await input;
    
        return either.MapSecond(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputThird, Task<TOutputThird>> transform)
    {
        var either = await input;

        return await either.MapThirdAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputThird, TOutputThird> transform)
    {
        var either = await input;
    
        return either.MapThird(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputSecond, Task<TOutputSecond>> transform)
    {
        var either = await input;

        return await either.MapSecondAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputSecond, TOutputSecond> transform)
    {
        var either = await input;
    
        return either.MapSecond(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputThird, Task<TOutputThird>> transform)
    {
        var either = await input;

        return await either.MapThirdAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputThird, TOutputThird> transform)
    {
        var either = await input;
    
        return either.MapThird(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputFourth, Task<TOutputFourth>> transform)
    {
        var either = await input;

        return await either.MapFourthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputFourth, TOutputFourth> transform)
    {
        var either = await input;
    
        return either.MapFourth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputSecond, Task<TOutputSecond>> transform)
    {
        var either = await input;

        return await either.MapSecondAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputSecond, TOutputSecond> transform)
    {
        var either = await input;
    
        return either.MapSecond(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputThird, Task<TOutputThird>> transform)
    {
        var either = await input;

        return await either.MapThirdAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputThird, TOutputThird> transform)
    {
        var either = await input;
    
        return either.MapThird(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFourth, Task<TOutputFourth>> transform)
    {
        var either = await input;

        return await either.MapFourthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFourth, TOutputFourth> transform)
    {
        var either = await input;
    
        return either.MapFourth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast>> MapFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFifth, Task<TOutputFifth>> transform)
    {
        var either = await input;

        return await either.MapFifthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputLast>> MapFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputFifth, TOutputFifth> transform)
    {
        var either = await input;
    
        return either.MapFifth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputSecond, Task<TOutputSecond>> transform)
    {
        var either = await input;

        return await either.MapSecondAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputSecond, TOutputSecond> transform)
    {
        var either = await input;
    
        return either.MapSecond(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputThird, Task<TOutputThird>> transform)
    {
        var either = await input;

        return await either.MapThirdAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputThird, TOutputThird> transform)
    {
        var either = await input;
    
        return either.MapThird(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFourth, Task<TOutputFourth>> transform)
    {
        var either = await input;

        return await either.MapFourthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFourth, TOutputFourth> transform)
    {
        var either = await input;
    
        return either.MapFourth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast>> MapFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFifth, Task<TOutputFifth>> transform)
    {
        var either = await input;

        return await either.MapFifthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputLast>> MapFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputFifth, TOutputFifth> transform)
    {
        var either = await input;
    
        return either.MapFifth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> when it's in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSixth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSixth">The type of the transformed Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast>> MapSixthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputSixth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputSixth, Task<TOutputSixth>> transform)
    {
        var either = await input;

        return await either.MapSixthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> when it's in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSixth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSixth">The type of the transformed Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputLast>> MapSixthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputSixth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputSixth, TOutputSixth> transform)
    {
        var either = await input;
    
        return either.MapSixth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFirst, Task<TOutputFirst>> transform)
    {
        var either = await input;

        return await either.MapFirstAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFirst"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFirst">The type of the transformed First output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the First state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TOutputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapFirstAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFirst>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFirst, TOutputFirst> transform)
    {
        var either = await input;
    
        return either.MapFirst(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSecond, Task<TOutputSecond>> transform)
    {
        var either = await input;

        return await either.MapSecondAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSecond"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSecond">The type of the transformed Second output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Second state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TOutputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapSecondAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSecond>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSecond, TOutputSecond> transform)
    {
        var either = await input;
    
        return either.MapSecond(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputThird, Task<TOutputThird>> transform)
    {
        var either = await input;

        return await either.MapThirdAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputThird"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputThird">The type of the transformed Third output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Third state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TOutputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapThirdAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputThird>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputThird, TOutputThird> transform)
    {
        var either = await input;
    
        return either.MapThird(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFourth, Task<TOutputFourth>> transform)
    {
        var either = await input;

        return await either.MapFourthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFourth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFourth">The type of the transformed Fourth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fourth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TOutputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> MapFourthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFourth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFourth, TOutputFourth> transform)
    {
        var either = await input;
    
        return either.MapFourth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast>> MapFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFifth, Task<TOutputFifth>> transform)
    {
        var either = await input;

        return await either.MapFifthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> when it's in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputFifth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputFifth">The type of the transformed Fifth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Fifth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TOutputFifth, TInputSixth, TInputSeventh, TInputLast>> MapFifthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputFifth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputFifth, TOutputFifth> transform)
    {
        var either = await input;
    
        return either.MapFifth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> when it's in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSixth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSixth">The type of the transformed Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast>> MapSixthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSixth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSixth, Task<TOutputSixth>> transform)
    {
        var either = await input;

        return await either.MapSixthAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> when it's in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSixth"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSixth">The type of the transformed Sixth output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Sixth state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TOutputSixth, TInputSeventh, TInputLast>> MapSixthAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSixth>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSixth, TOutputSixth> transform)
    {
        var either = await input;
    
        return either.MapSixth(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> when it's in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSeventh"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSeventh">The type of the transformed Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast>> MapSeventhAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSeventh>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSeventh, Task<TOutputSeventh>> transform)
    {
        var either = await input;

        return await either.MapSeventhAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> when it's in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputSeventh"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputSeventh">The type of the transformed Seventh output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Seventh state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TOutputSeventh, TInputLast>> MapSeventhAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputSeventh>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputSeventh, TOutputSeventh> transform)
    {
        var either = await input;
    
        return either.MapSeventh(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputLast, Task<TOutputLast>> transform)
    {
        var either = await input;

        return await either.MapLastAsync(transform);
    }

    /// <summary>
    ///      Performs transformation into <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> when it's in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> in the appropriate state.
    /// </summary>
    /// <param name="input">The asynchronous input to transform.</param>
    /// <param name="transform">The function to transform to <typeparamref name="TOutputLast"/>.</param>
    /// <typeparam name="TInputFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TInputLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <typeparam name="TOutputLast">The type of the transformed Last output.</typeparam>
    /// <returns>
    ///      The result of <paramref name="transform"/> if in the Last state,
    ///      otherwise returns <see cref="Task"/> of type <see cref="Either{TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast}"/> in the appropriate state.
    /// </returns>
    public static async Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TOutputLast>> MapLastAsync<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast, TOutputLast>(
        this Task<Either<TInputFirst, TInputSecond, TInputThird, TInputFourth, TInputFifth, TInputSixth, TInputSeventh, TInputLast>> input,
        Func<TInputLast, TOutputLast> transform)
    {
        var either = await input;
    
        return either.MapLast(transform);
    }
}