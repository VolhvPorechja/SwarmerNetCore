using System;

namespace Swarmer.Common
{
	/// <summary>
	/// Exception that occures in business logic.
	/// </summary>
	public class BusinsessLogicException : Exception
	{
		public BusinsessLogicException(string code)
		{
			Code = code;
		}

		public BusinsessLogicException(string code, string message) : base(message)
		{
			Code = code;
		}

		public BusinsessLogicException(string code, string message, Exception innerException) : base(message, innerException)
		{
			Code = code;
		}

		public string Code { get; }
	}
}