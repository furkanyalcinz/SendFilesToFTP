using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logging.TextLogger
{
    public class TextLogger
    {
        public static void WriteInformationLog(string logText)
        {
            SetLoggerConfiguration();
            Log.Information(logText);
            Log.CloseAndFlush();
        }
        public static void WriteErrorLog(string logText)
        {
            SetLoggerConfiguration();
            Log.Error(logText);
            Log.CloseAndFlush();
        }
        public static void WriteInformationLog(string serviceName, string logText)
        {
            SetLoggerConfiguration();
            Log.Information(serviceName + " > " + logText);
            Log.CloseAndFlush();
        }
        public static void WriteErrorLog(string serviceName, string logText)
        {
            SetLoggerConfiguration();
            Log.Error(serviceName + " > " + logText);
            Log.CloseAndFlush();
        }
        private static void SetLoggerConfiguration()
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory + @"\logs\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }


}       
