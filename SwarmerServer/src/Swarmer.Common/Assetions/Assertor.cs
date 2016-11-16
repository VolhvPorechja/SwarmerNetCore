using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Swarmer.Common.Assetions
{
    /// <summary>
	/// Class for collecting assertions statements and accumulation assertion messages.
	/// </summary>
	public class Assertor
	{
		protected readonly List<Tuple<Func<bool>,string, bool>> mAssertStatements = new List<Tuple<Func<bool>, string, bool>>();
		private readonly Func<string, Exception> mExceptionCreator;

		private static readonly Func<string, Exception> DefaultExceptionCreator = mess => new Exception(mess);

		public Assertor(Func<string, Exception> exceptionCreator = null)
		{
			mExceptionCreator = exceptionCreator ?? DefaultExceptionCreator;
		}

		/// <summary>
		/// Add statement in assertion script.
		/// </summary>
		/// <param name="statement">Checking statement.</param>
		/// <param name="message">Assertion message.</param>
		/// <param name="stopProcessing">Stop statements processing if given assertion failed.</param>
		/// <returns></returns>
		public Assertor Add(Func<bool> statement, string message, bool stopProcessing = false)
		{
			mAssertStatements.Add(new Tuple<Func<bool>, string, bool>(statement, message, stopProcessing));
			return this;
		}

		/// <summary>
		/// Assert with exception.
		/// </summary>
		public void Assert()
		{
			var assertionMessage = GetMessage();
			if (!string.IsNullOrEmpty(assertionMessage))
				throw mExceptionCreator(assertionMessage);
		}

		/// <summary>
		/// Get accumulated message of assertions messages.
		/// </summary>
		/// <returns></returns>
		public string GetMessage()
		{
			StringBuilder result = new StringBuilder();
			StringWriter wr = new StringWriter(result);

			foreach (var assertStatement in mAssertStatements)
			{
				if (!assertStatement.Item1())
					wr.WriteLine(assertStatement.Item2);

				if(assertStatement.Item3)
					break;
			}

			return result.ToString().Trim();
		}
	}
}