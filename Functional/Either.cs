using System;

public class Either<TSuccess, TFailure>
{
    private readonly TSuccess _success;
    private readonly TFailure _failure;
    private readonly bool _isSuccessful;

    public bool Succeeded
    {
        get
        {
            return this._isSuccessful;
        }
    }

    public TSuccess SuccessValue
    {
        get
        {
            if (!this._isSuccessful)
                throw new InvalidOperationException("Cannot get a successful result when in a failure state.");
            return this._success;
        }
    }

    public TFailure FailureValue
    {
        get
        {
            if (this._isSuccessful)
                throw new InvalidOperationException("Cannot get a failure result when in a success state.");
            return this._failure;
        }
    }

    public Either(TSuccess success)
    {
        this._success = success;
        this._isSuccessful = true;
        this._failure = default(TFailure);
    }

    public Either(TFailure failure)
    {
        this._success = default(TSuccess);
        this._isSuccessful = false;
        this._failure = failure;
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