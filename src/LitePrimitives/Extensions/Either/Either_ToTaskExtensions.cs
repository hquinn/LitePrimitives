namespace LitePrimitives;

public static class Either_ToTaskExtensions
{
   /// <summary>
   ///     Creates a <see cref="Task"/> from <see cref="Either{TLeft, TRight}"/>.
   /// </summary>
   /// <param name="input">The input to create into a <see cref="Task"/>.</param>
   /// <typeparam name="TLeft">The type of the Left <paramref name="input"/>.</typeparam>
   /// <typeparam name="TRight">The type of the Right <paramref name="input"/>.</typeparam>
   /// <returns>The created <see cref="Task"/> of from the <paramref name="input"/>.</returns>
   public static Task<Either<TLeft, TRight>> ToTask<TLeft, TRight>(this Either<TLeft, TRight> input)
   {
      return Task.FromResult(input);
   }
}