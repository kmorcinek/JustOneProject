using System;
using System.Diagnostics.CodeAnalysis;

    public struct Option<T> : IEquatable<Option<T>>
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly Option<T> None = new Option<T>();
        private readonly T _value;
        private readonly bool _hasValue;

        public T Value
        {
            get
            {
                if (!this._hasValue)
                    throw new InvalidOperationException("Value is not set");
                return this._value;
            }
        }

        public bool HasValue
        {
            get
            {
                return this._hasValue;
            }
        }

        public Option(T value)
        {
            if ((object)value != null)
            {
                this._value = value;
                this._hasValue = true;
            }
            else
            {
                this._value = default(T);
                this._hasValue = false;
            }
        }

        public static implicit operator Option<T>(T value)
        {
            if ((object)value == null)
                return Option<T>.None;
            return new Option<T>(value);
        }

        public static bool operator ==(Option<T> first, Option<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Option<T> first, Option<T> second)
        {
            return !(first == second);
        }

        public override int GetHashCode()
        {
            if (this._hasValue)
                return this.Value.GetHashCode();
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Option<T>)
                return this.Equals((Option<T>)obj);
            return false;
        }

        public bool Equals(Option<T> other)
        {
            if (!this.HasValue && !other.HasValue)
                return true;
            if (this.HasValue && other.HasValue)
                return this._value.Equals((object)other.Value);
            return false;
        }

        bool IEquatable<Option<T>>.Equals(Option<T> other)
        {
            return this.Equals(other);
        }

        public T GetValueOrDefault(T @default)
        {
            if (!this.HasValue)
                return @default;
            return this._value;
        }

        public T GetValueOrDefault()
        {
            if (!this.HasValue)
                return default(T);
            return this._value;
        }
    }