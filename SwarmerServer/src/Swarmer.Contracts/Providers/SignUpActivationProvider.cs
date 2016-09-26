using Swarmer.AM.Contracts.Providers.Contracts;

namespace Swarmer.AM.Contracts.Providers
{
    /// <summary>
    /// Contract for signup activation provider.
    /// </summary>
    public interface SignUpActivationProviderContract
    {
        /// <summary>
        /// Storing sign up data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Key with which signup data can be extracted.</returns>
        string StoreSignUpData(SignUpData data);

        /// <summary>
        /// Get sign up data by key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Signup data.</returns>
        SignUpData GetSignUpData(string key);
    }
}