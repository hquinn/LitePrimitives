// ReSharper disable once CheckNamespace
namespace LitePrimitives;

/// <summary>
///     Collection of extension methods for To Task on the Either type.
/// </summary>
public static class EitherToTaskExtensions
{
    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TLast>> ToTask<TFirst, TLast>(
        this Either<TFirst, TLast> input)
    {
        return Task.FromResult(input);
    }

    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TSecond, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TSecond, TLast>> ToTask<TFirst, TSecond, TLast>(
        this Either<TFirst, TSecond, TLast> input)
    {
        return Task.FromResult(input);
    }

    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TSecond, TThird, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TSecond, TThird, TLast>> ToTask<TFirst, TSecond, TThird, TLast>(
        this Either<TFirst, TSecond, TThird, TLast> input)
    {
        return Task.FromResult(input);
    }

    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TSecond, TThird, TFourth, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TSecond, TThird, TFourth, TLast>> ToTask<TFirst, TSecond, TThird, TFourth, TLast>(
        this Either<TFirst, TSecond, TThird, TFourth, TLast> input)
    {
        return Task.FromResult(input);
    }

    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast>> ToTask<TFirst, TSecond, TThird, TFourth, TFifth, TLast>(
        this Either<TFirst, TSecond, TThird, TFourth, TFifth, TLast> input)
    {
        return Task.FromResult(input);
    }

    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>> ToTask<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast>(
        this Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TLast> input)
    {
        return Task.FromResult(input);
    }

    /// <summary>
    ///     Creates a <see cref="Task"/> from <see cref="Either{TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast}"/>.
    /// </summary>
    /// <param name="input">The input to create into a <see cref="Task"/>.</param>
    /// <typeparam name="TFirst">The type of the First <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSecond">The type of the Second <paramref name="input"/>.</typeparam>
    /// <typeparam name="TThird">The type of the Third <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFourth">The type of the Fourth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TFifth">The type of the Fifth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSixth">The type of the Sixth <paramref name="input"/>.</typeparam>
    /// <typeparam name="TSeventh">The type of the Seventh <paramref name="input"/>.</typeparam>
    /// <typeparam name="TLast">The type of the Last <paramref name="input"/>.</typeparam>
    /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
    public static Task<Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>> ToTask<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast>(
        this Either<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TLast> input)
    {
        return Task.FromResult(input);
    }
}