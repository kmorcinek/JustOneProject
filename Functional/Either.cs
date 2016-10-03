using System;

public class Either<TSuccess, TFailure>
{
    readonly TSuccess _success;
    readonly TFailure _failure;
    readonly bool _isSuccessful;

    public bool Succeeded
    {
        get
        {
            return _isSuccessful;
        }
    }

    public TSuccess SuccessValue
    {
        get
        {
            if (!_isSuccessful)
                throw new InvalidOperationException("Cannot get a successful result when in a failure state.");
            return _success;
        }
    }

    public TFailure FailureValue
    {
        get
        {
            if (_isSuccessful)
                throw new InvalidOperationException("Cannot get a failure result when in a success state.");
            return _failure;
        }
    }

    public Either(TSuccess success)
    {
        _success = success;
        _isSuccessful = true;
        _failure = default(TFailure);
    }

    public Either(TFailure failure)
    {
        _success = default(TSuccess);
        _isSuccessful = false;
        _failure = failure;
    }

    public static implicit operator Either<TSuccess, TFailure>(TSuccess value)
    {
        return new Either<TSuccess, TFailure>(value);
    }

    public static implicit operator Either<TSuccess, TFailure>(TFailure value)
    {
        return new Either<TSuccess, TFailure>(value);
    }
}