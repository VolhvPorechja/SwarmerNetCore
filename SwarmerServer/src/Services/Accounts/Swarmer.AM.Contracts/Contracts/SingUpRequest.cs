using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.Contracts.Contracts
{
    /// <summary>
    /// Request for singup.
    /// </summary>
    public class SingUpRequest
    {
        /// <summary>
        /// User data for sing up.
        /// </summary>
        public UserData Data { get; set; }

        /// <summary>
        /// Password of user that will be setted.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Key of activation for user email approuvance.
        /// </summary>
        public string ActivationKey { get; set; }
    }
}