using System;
using Swarmer.Common.Models;

namespace Swarmer.AM.Contracts.Contracts
{
    /// <summary>
    /// Authentication data.
    /// </summary>
    public class AuthneticationData : SysObject
    {
        /// <summary>
        /// Id of user that owns this authentication data.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Type of authentication data (login/password, facebook, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Secret for account owning trial.
        /// </summary>
        public string Secret { get; set; }
    }
}