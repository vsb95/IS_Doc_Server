using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace IS_Doc_Server.Classes.Log
{
    public static class Logger
    {
        private static NLog.Logger _logger = LogManager.GetCurrentClassLogger();
        static Logger()
        {
        }
        public static void Debug(string message)
        {
            _logger.Debug(message);
        }
        public static void Info(string message)
        {
            _logger.Info(message);
        }
        public static void Warn(string message)
        {
            _logger.Warn(message);
        }
        public static void Error(string message)
        {
            _logger.Error(message);
        }
        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }
        public static void WarnException(Exception exception)
        {
            _logger.Log(LogLevel.Warn, exception);
        }
        public static void FatalException(Exception exception)
        {
            _logger.Log(LogLevel.Fatal, exception);
        }

    }
}
