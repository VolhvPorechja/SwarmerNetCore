namespace Swarmer.AM.Contracts.Contracts
{
    /// <summary>
    /// Authentication info.
    /// </summary>
    public class AuthRequest
    {
        public string Id { get; set; }
        public string Secret { get; set; }
    }
}