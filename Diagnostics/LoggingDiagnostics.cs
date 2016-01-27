using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JustOneProject.Diagnostics
{
    public class LoggingDiagnostics
    {
        [Conditional("DEBUG")]
        public static void LogMessage(string message)
        {
            Debug.WriteLine(message);
        }

        [Conditional("DEBUG")]
        public static void LogWithCurrentLocalTime(string message)
        {
            Debug.WriteLine("Time: '{0}', message: '{1}'", DateTime.Now.ToString("O"), message);
        }

        [Conditional("DEBUG")]
        public static void LogWithCurrentLocalTimeAndCurrentMethod([CallerMemberName] string invokingMethodName = null)
        {
            LogWithCurrentLocalTime(FormatInvokingMethodMessage(invokingMethodName));
        }

        [Conditional("DEBUG")]
        public static void LogCurrentMethod([CallerMemberName] string invokingMethodName = null)
        {
            Debug.WriteLine(FormatInvokingMethodMessage(invokingMethodName));
        }

        private static string FormatInvokingMethodMessage(string invokingMethodName)
        {
            return "Invoking method name is " + invokingMethodName;
        }
    }
}