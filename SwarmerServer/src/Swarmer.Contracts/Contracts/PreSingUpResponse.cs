namespace Swarmer.AM.Contracts.Contracts
{
    /// <summary>
    /// Response on pre sign request.
    /// </summary>
    public class PreSingUpResponse
    {
        /// <summary>
        /// Flag of successfull operation.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Is login already not vacant.
        /// </summary>
        public bool LoginExists { get; set; }

        /// <summary>
        /// Is email already not vacant.
        /// </summary>
        public bool EmailExists { get; set; }

        /// <summary>
        /// Resirect url.
        /// </summary>
        public string Url { get; set; }
    }
}