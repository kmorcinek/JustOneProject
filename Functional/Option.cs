using System;
using System.Diagnostics.CodeAnalysis;

    public struct Option<T> : IEquatable<Option<T>>
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly Option<T> None = new Option<T>();

        readonly T _value;
        readonly bool _hasValue;

        public T Value
        {
            get
            {
                if (!_hasValue)
                    throw new InvalidOperationException("Value is not set");
                return _value;
            }
        }

        public bool HasValue
        {
            get
            {
                return _hasValue;
            }
        }

        public Option(T value)
        {
            if (value != null)
            {
                _value = value;
                _hasValue = true;
            }
            else
            {
                _value = default(T);
                _hasValue = false;
            }
        }

        public static implicit operator Option<T>(T value)
        {
            if (value == null)
                return None;
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
            if (_hasValue)
                return Value.GetHashCode();
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Option<T>)
                return Equals((Option<T>)obj);
            return false;
        }

        public bool Equals(Option<T> other)
        {
            if (!HasValue && !other.HasValue)
                return true;
            if (HasValue && other.HasValue)
                return _value.Equals(other.Value);
            return false;
        }

        bool IEquatable<Option<T>>.Equals(Option<T> other)
        {
            return Equals(other);
        }

        public T GetValueOrDefault(T @default)
        {
            if (!HasValue)
                return @default;
            return _value;
        }

        public T GetValueOrDefault()
        {
            if (!HasValue)
                return default(T);
            return _value;
        }
    }