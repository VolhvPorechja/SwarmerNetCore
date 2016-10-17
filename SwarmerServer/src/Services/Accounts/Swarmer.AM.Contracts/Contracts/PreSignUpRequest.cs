namespace Swarmer.AM.Contracts.Contracts
{
    /// <summary>
    /// Pre sing up request.
    /// </summary>
    public class PreSignUpRequest
    {
        /// <summary>
        /// Login that will be bind to new user.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Email that will be bind to new user.
        /// </summary>
        public string Email { get; set; }
    }
}