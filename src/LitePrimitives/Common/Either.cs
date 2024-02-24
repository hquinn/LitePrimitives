namespace LitePrimitives;

/// <summary>
///     Represents a value of one of two possible types (a disjointed union). This type can encapsulate either
///     a value of type <typeparamref name="TLeft"/> in the Left state, or a value of type <typeparamref name="TRight"/>
///     in the Right state, but not both. 
/// </summary>
/// <typeparam name="TLeft">The type of the Left state.</typeparam>
/// <typeparam name="TRight">The type of the Right state.</typeparam>
public readonly struct Either<TLeft, TRight>
{
	private readonly EitherState _state;
	private readonly TLeft? _left;
    private readonly TRight? _right;

	private Either(TLeft left)
	{
		_left = left;
		_state = EitherState.Left;
	}

	private Either(TRight right)
	{
		_right = right;
		_state = EitherState.Right;
	}

	/// <summary>
	///     Outputs the <paramref name="left"/> if in the Left state, otherwise outputs the <paramref name="right"/>.
	///     The output is of type <typeparamref name="TOutput"/>.
	/// </summary>
	/// <param name="left">The func to use if <see cref="Either{TLeft, TRight}"/> is in the Left state.</param>
	/// <param name="right">The func to use if <see cref="Either{TLeft, TRight}"/> is in the Right state.</param>
	/// <typeparam name="TOutput">The output of the match.</typeparam>
	/// <returns>The output of the match.</returns>
	public TOutput Match<TOutput>(
		Func<TLeft, TOutput> left, 
		Func<TRight, TOutput> right)
	{
		return _state is EitherState.Left 
			? left(_left!) 
			: right(_right!);
	}

	/// <summary>
	///     Outputs the <paramref name="left"/> if in the Left state, otherwise outputs the <paramref name="right"/>.
	///     The output is of type <see cref="Task"/> of <typeparamref name="TOutput"/>.
	/// </summary>
	/// <param name="left">The func to use if <see cref="Either{TLeft, TRight}"/> is in the Left state.</param>
	/// <param name="right">The func to use if <see cref="Either{TLeft, TRight}"/> is in the Right state.</param>
	/// <typeparam name="TOutput">The output of the match.</typeparam>
	/// <returns>The output of the match.</returns>
	public Task<TOutput> MatchAsync<TOutput>(
		Func<TLeft, Task<TOutput>> left, 
		Func<TRight, Task<TOutput>> right)
	{
		return _state is EitherState.Left 
			? left(_left!) 
			: right(_right!);
	}

	/// <summary>
	///     Constructs <see cref="Either{TLeft, TRight}"/> from a <typeparamref name="TLeft"/> in the Left state.
	/// </summary>
	/// <param name="left">The value to construct the <see cref="Either{TLeft, TRight}"/> type from.</param>
	/// <returns>The <see cref="Either{TLeft, TRight}"/> type in the Left state.</returns>
	public static Either<TLeft, TRight> Left(TLeft left)
	{
		return new Either<TLeft, TRight>(left);
	}

	/// <summary>
	///     Constructs <see cref="Either{TLeft, TRight}"/> from a <typeparamref name="TRight"/> in the Right state.
	/// </summary>
	/// <param name="right">The value to construct the <see cref="Either{TLeft, TRight}"/> type from.</param>
	/// <returns>The <see cref="Either{TLeft, TRight}"/> type in the Right state.</returns>
	public static Either<TLeft, TRight> Right(TRight right)
	{
		return new Either<TLeft, TRight>(right);
	}
}