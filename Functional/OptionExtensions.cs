using System;
using System.ComponentModel;
using System.Diagnostics;

public static class OptionExtensions
{
    public static Either<TSuccess, TFailure> ToEither<TSuccess, TFailure>(this Option<TSuccess> option, TFailure failureValue)
    {
        if (option.HasValue)
            return new Either<TSuccess, TFailure>(option.Value);
        return new Either<TSuccess, TFailure>(failureValue);
    }

    [DebuggerStepThrough]
    public static Option<T> ToOption<T>(this T obj)
    {
        if ((object)obj == null)
            return Option<T>.None;
        return new Option<T>(obj);
    }

    [DebuggerStepThrough]
    public static Option<TOut> Try<T, TOut>(this Option<T> option, Func<T, TOut> func)
    {
        if (option.HasValue)
            return new Option<TOut>(func(option.Value));
        return Option<TOut>.None;
    }

    [DebuggerStepThrough]
    public static Option<T> IfNone<T>(this Option<T> option, Func<Option<T>> continuation)
    {
        if (option.HasValue)
            return option;
        return continuation();
    }

    [DebuggerStepThrough]
    public static Option<TOut> IfSome<T, TOut>(this Option<T> option, Func<T, Option<TOut>> continuation)
    {
        if (option.HasValue)
            return continuation(option.Value);
        return Option<TOut>.None;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerStepThrough]
    public static Option<TResult> SelectMany<TSource, TResult>(this Option<TSource> option, Func<TSource, Option<TResult>> continuation)
    {
        return OptionExtensions.IfSome<TSource, TResult>(option, continuation);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerStepThrough]
    public static Option<TResult2> SelectMany<TSource, TResult1, TResult2>(this Option<TSource> source, Func<TSource, Option<TResult1>> continuation, Func<TSource, TResult1, TResult2> projection)
    {
        return OptionExtensions.IfSome<TSource, TResult2>(source, (Func<TSource, Option<TResult2>>)(x => OptionExtensions.IfSome<TResult1, TResult2>(continuation(x), (Func<TResult1, Option<TResult2>>)(y => new Option<TResult2>(projection(x, y))))));
    }
}