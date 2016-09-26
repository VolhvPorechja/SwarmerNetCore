using System;

namespace Swarmer.AM.Contracts.Contracts
{
    public class UserData
    {
        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User second name.
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Chousen login.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User's gender.
        /// </summary>
        /// <value>User's gender.</value>
        public string Gender { get; set; }

        /// <summary>
        /// User birth date.
        /// </summary>
        /// <value>User birth date.</value>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// User's time zone for time correction.
        /// </summary>
        /// <value>User's time zone for time correction.</value>
        public int? TimeZone { get; set; }

        /// <summary>
        /// User's living country.
        /// </summary>
        /// <value>User's living country.</value>
        public string Country { get; set; }
    }
}