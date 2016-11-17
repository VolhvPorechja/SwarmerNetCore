using NLog;

namespace Swarmer.Common.Logging
{
    /// <summary>
    /// Logger for composing functionality of NLog logger and log messages manager.
    /// </summary>
    public class SystemLogger
    {
        private readonly ILogger mLogger;
        private readonly LogMessagesManager mManager;

        public SystemLogger(ILogger logger, LogMessagesManager manager)
        {
            mManager = manager;
            mLogger = logger;
        }


        /// <summary>
        /// Log message with info level.
        /// </summary>
        /// <param name="initiator"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        public void Info(string initiator, string code, string message, string referenceId = null, object data = null)
        {
            mLogger?.Info(mManager.Log(initiator, code, message, referenceId, data));
        }

        /// <summary>
        /// Log message with info level.
        /// </summary>
        /// <param name="initiator"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        public void Debug(string initiator, string code, string message, string referenceId = null, object data = null)
        {
            mLogger?.Debug(mManager.Log(initiator, code, message, referenceId, data));
        }

        /// <summary>
        /// Log message with info level.
        /// </summary>
        /// <param name="initiator"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        public void Trace(string initiator, string code, string message, string referenceId = null, object data = null)
        {
            mLogger?.Trace(mManager.Log(initiator, code, message, referenceId, data));
        }

        /// <summary>
        /// Log message with info level.
        /// </summary>
        /// <param name="initiator"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        public void Warn(string initiator, string code, string message, string referenceId = null, object data = null)
        {
            mLogger?.Warn(mManager.Log(initiator, code, message, referenceId, data));
        }

        /// <summary>
        /// Log message with info level.
        /// </summary>
        /// <param name="initiator"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        public void Error(string initiator, string code, string message, string referenceId = null, object data = null)
        {
            mLogger?.Error(mManager.Log(initiator, code, message, referenceId, data));
        }

        /// <summary>
        /// Log message with info level.
        /// </summary>
        /// <param name="initiator"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        public void Fatal(string initiator, string code, string message, string referenceId = null, object data = null)
        {
            mLogger?.Fatal(mManager.Log(initiator, code, message, referenceId, data));
        }
    }
}