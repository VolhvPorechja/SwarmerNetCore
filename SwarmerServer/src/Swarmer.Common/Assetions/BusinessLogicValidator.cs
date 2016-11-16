using System;

namespace Swarmer.Common.Assetions
{
    /// <summary>
    /// Class for incomming request validation.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class RequestValidator<TRequest> : Assertor
    {
        private readonly TRequest mRequest;

        public RequestValidator(TRequest request) : base(mess => new BusinsessLogicException("VALIDATION", mess))
        {
            mRequest = request;
            Add(req => req != null, "Empty request not allowed", true);
        }

        /// <summary>
		/// Add statement in assertion script.
		/// </summary>
		/// <param name="statement">Checking statement.</param>
		/// <param name="message">Assertion message.</param>
		/// <param name="stopProcessing">Stop statements processing if given assertion failed.</param>
		/// <returns></returns>
		public Assertor Add(Func<TRequest, bool> statement, string message, bool stopProcessing = false)
        {
            mAssertStatements.Add(new Tuple<Func<bool>, string, bool>(() => statement(mRequest), message, stopProcessing));
            return this;
        }
    }
}