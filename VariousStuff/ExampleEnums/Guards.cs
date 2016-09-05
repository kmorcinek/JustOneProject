using System;

namespace JustOneProject.VariousStuff.ExampleEnums
{
    public class Guards
    {
        public static ArgumentOutOfRangeException CreateMissingEnumException<T>(string paramName, T value)
            where T : struct
        {
            return new ArgumentOutOfRangeException(paramName, value,
                $"Enum '{typeof(T).Name}' has invalid value '{value}'");
        }

        public static ArgumentOutOfRangeException CreateMissingEnumException<T>(string paramName, T? value)
            where T : struct
        {
            return new ArgumentOutOfRangeException(paramName, value,
                $"Nullable enum '{typeof(T).Name}' has invalid value '{value}'");
        }
    }
}