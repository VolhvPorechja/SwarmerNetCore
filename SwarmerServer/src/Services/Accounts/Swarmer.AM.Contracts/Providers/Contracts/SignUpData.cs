namespace Swarmer.AM.Contracts.Providers.Contracts
{
    /// <summary>
    /// Data stored on pre sign up for further activation.
    /// </summary>
    public class SignUpData
    {
        public string Login { get; set; }
        public string Email { get; set; }
    }
}