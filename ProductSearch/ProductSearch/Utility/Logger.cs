using System;
using log4net;

namespace ProductSearch.Utility
{
    public class Logger
    {
        private readonly ILog _logger;

        public Logger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }

        public static Logger GetLogger(Type type)
        {
            return new Logger(type);
        }

        public static Logger GetLogger(object instance)
        {
            return new Logger(instance.GetType());
        }

        public void Debug(string logMsg)
        {
            _logger.Debug(logMsg);
        }

        public void Debug(string logMsg, Exception e)
        {
            _logger.Debug(logMsg, e);
        }

        public void Info(string logMsg)
        {
            _logger.Info(logMsg);
        }

        public void Info(string logMsg, Exception e)
        {
            _logger.Info(logMsg, e);
        }

        public void Warn(string logMsg)
        {
            _logger.Warn(logMsg);
        }

        public void Warn(string logMsg, Exception e)
        {
            _logger.Warn(logMsg, e);
        }

        public void Error(string logMsg)
        {
            _logger.Error(logMsg);
        }

        public void Error(string logMsg, Exception e)
        {
            _logger.Error(logMsg, e);
        }

        public void Fatal(string logMsg)
        {
            _logger.Fatal(logMsg);
        }

        public void Fatal(string logMsg, Exception e)
        {
            _logger.Fatal(logMsg, e);
        }
    }
}
