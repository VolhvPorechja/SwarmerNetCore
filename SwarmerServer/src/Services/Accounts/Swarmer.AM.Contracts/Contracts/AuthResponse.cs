namespace Swarmer.AM.Contracts.Contracts
{
    /// <summary>
    /// Authentication response.
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// Is authentication was successfull.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Redirection url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Authentication response for successfull login.
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        public static AuthResponse Success(string redirectUrl = null)
        {
            return new AuthResponse
            {
                IsSuccess = true,
                Url = redirectUrl
            };
        }

        /// <summary>
        /// Authentication response for unsuccessfull login.
        /// </summary>
        /// <returns></returns>
        public static AuthResponse Fail()
        {
            return new AuthResponse
            {
                IsSuccess = false
            };
        }
    }
}