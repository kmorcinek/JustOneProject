namespace JustOneProject.AutoFixtureExamples
{
    public class ImmutableExample
    {
        public int Age { get; }
        public string Name { get; }

        public ImmutableExample(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public ImmutableExample WithAge(int age)
        {
            return new ImmutableExample(age, Name);
        }
    }
}