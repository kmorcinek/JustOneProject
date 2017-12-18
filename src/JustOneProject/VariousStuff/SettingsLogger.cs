using Newtonsoft.Json;

namespace JustOneProject.VariousStuff
{
    public static class SettingsLoggerRunner
    {
        public static void Main()
        {
            SettingsLogger.LogSettings("inv", new AbcServiceSettings()
            {
                Url = "https://ostrapila.pl"
            });
        }
    }

    public class SettingsLogger
    {
        public static void LogSettings(
            string inventoryPath,
            AbcServiceSettings abcServiceSettings)
        {
            string userName = UserNameService.GetUserName();

            var settings = new
            {
                inventoryPath,
                LocalUserName = userName,
                abcServiceSettings
            };

            string serializedSettings = JsonConvert.SerializeObject(settings);

            //Logger.Info(serializedSettings);
        }
    }

    public class AbcServiceSettings
    {
        public string Url { get; set; }
    }

    public class UserNameService
    {
        public static string GetUserName()
        {
            return "konik";
        }
    }
}