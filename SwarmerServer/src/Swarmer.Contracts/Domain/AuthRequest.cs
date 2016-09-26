namespace Swarmer.AM.Contracts.Domain
{
    public class LogoutResponse
    {
        
    }

    /// <summary>
    /// Authentication info.
    /// </summary>
    public class AuthRequest
    {
        public string Id { get; set; }
        public string Secret { get; set; }
    }
}