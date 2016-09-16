using System;

namespace Swarmer.AM.Core
{
	/// <summary>
	/// Occured if incomming request was not correct.
	/// </summary>
	public class NotValidRequestException : Exception
	{
		/// <summary>
		/// CTOR
		/// </summary>
		/// <param name="message"></param>
		public NotValidRequestException(string message) : base(message) { }
	}
}