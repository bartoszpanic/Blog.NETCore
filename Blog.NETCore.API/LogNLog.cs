using NLog;
using System;

namespace Blog.NETCore.API
{
    public class LogNLog : ILogNLog
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public LogNLog()
        {
        }
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception exp)
        {
            logger.Error(exp);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
    public interface ILogNLog
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception exp);
    }
}
