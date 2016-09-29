using Newtonsoft.Json;

namespace JustOneProject.VariousStuff.ValueObject
{
    /// <summary>
    /// Example of Value Object, showing serialization problems.
    /// Implementation is very limited so it's not good general example
    /// </summary>
    public class Money
    {
        public static Money Create(decimal value, string currency)
        {
            // some additional checks
            return new Money(value, currency);
        }

        [JsonConstructor]
        Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; }
        public string Currency { get; }
    }
}