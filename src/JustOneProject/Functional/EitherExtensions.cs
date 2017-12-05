using System;
using System.ComponentModel;
using System.Diagnostics;

public static class EitherExtensions
{
    [DebuggerStepThrough]
    public static Either<TNew, TFailure> IfSuccess<TCurrent, TNew, TFailure>(this Either<TCurrent, TFailure> either, Func<TCurrent, Either<TNew, TFailure>> continuation)
    {
        if (!either.Succeeded)
            return new Either<TNew, TFailure>(either.FailureValue);
        return continuation(either.SuccessValue);
    }

    [DebuggerStepThrough]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Either<TNewSuccess, TFailure> SelectMany<TSuccess, TNewSuccess, TFailure>(this Either<TSuccess, TFailure> either, Func<TSuccess, Either<TNewSuccess, TFailure>> continuation)
    {
        return either.IfSuccess(continuation);
    }

    [DebuggerStepThrough]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Either<TSuccess2, TFailure> SelectMany<TSuccess, TSuccess1, TSuccess2, TFailure>(this Either<TSuccess, TFailure> either, Func<TSuccess, Either<TSuccess1, TFailure>> continuation, Func<TSuccess, TSuccess1, TSuccess2> projection)
    {
        return IfSuccess(either, x => IfSuccess(continuation(x), y => new Either<TSuccess2, TFailure>(projection(x, y))));
    }

    public static TSuccess GetSuccessOrDefault<TSuccess, TFailure>(this Either<TSuccess, TFailure> either, TSuccess @default)
    {
        if (either.Succeeded)
            return either.SuccessValue;
        return @default;
    }

    public static Option<TSuccess> SuccessToOption<TSuccess, TFailure>(this Either<TSuccess, TFailure> either)
    {
        if (either.Succeeded)
            return either.SuccessValue.ToOption();
        return Option<TSuccess>.None;
    }
}