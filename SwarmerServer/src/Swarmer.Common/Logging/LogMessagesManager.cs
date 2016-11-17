using Newtonsoft.Json.Linq;

namespace Swarmer.Common.Logging
{
    /// <summary>
	/// Special class responsible for creating log messages.
	/// </summary>
	public class LogMessagesManager
	{
		private readonly string mSysCodePrefix;

	    public LogMessagesManager(string sysCodePrefix)
	    {
	        mSysCodePrefix = sysCodePrefix;
	    }

		/// <summary>
		/// Create log message.
		/// </summary>
		/// <param name="initiator">Initiator of operation.</param>
		/// <param name="code">Operation code.</param>
		/// <param name="message">Message of log.</param>
		/// <param name="referenceId">Reference Id of operation.</param>
		/// <param name="data">Additional data.</param>
		/// <returns></returns>
		public string Log(string initiator, string code, string message, string referenceId = null, object data = null)
		{
			return new LogMessage
			{
				Initiator = initiator,
				Code = $"{mSysCodePrefix}:{code}",
				Message = message,
				Data = data != null ? JObject.FromObject(data) : null,
				ReferenceId = referenceId,

			}.ToJString();
		}
	}
}