namespace KMorcinek.SpecFlowExample.Extensions
{
    // ReSharper disable once UnusedTypeParameter
    // Reason: it is to carry the knowledge of wrapped type.
    public class NameWithType<T>
    {
        public string Name { get; }

        public NameWithType(string name)
        {
            Name = name;
        }
    }
}