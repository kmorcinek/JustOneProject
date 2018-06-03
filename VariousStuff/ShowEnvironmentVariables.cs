using System;

namespace JustOneProject.VariousStuff
{
    public class ShowEnvironmentVariables
    {
        [STAThread]
        public static void Main()
        {
            SetEnvVar("POSTGRES_DB", "local_db2");
            SetEnvVar("POSTGRES_HOST", "localhost");
            SetEnvVar("POSTGRES_USER", "local_db2");
            SetEnvVar("POSTGRES_PASSWORD", "secret");

            ShowVar("POSTGRES_DB");
            ShowVar("POSTGRES_HOST");
            ShowVar("POSTGRES_USER");
            ShowVar("POSTGRES_PASSWORD");

            Console.WriteLine("changed");
            Console.ReadLine();
        }

        private static void ShowVar(string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);

            Console.WriteLine($"{name}: '{value}'");
        }

        private static void SetEnvVar(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User);
        }
    }
}