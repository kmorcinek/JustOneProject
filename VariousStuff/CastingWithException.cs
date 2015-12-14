namespace JustOneProject.VariousStuff
{
    public class CastingWithException
    {
        public object Value { get; set; } // Default value is null

        public static void CheckIfCanCast()
        {
            var castingWithException = new CastingWithException();
            bool isGood = (bool) castingWithException.Value;
        }
    }
}