/*
 * Swarmer API
 *
 * Internal Swarmer API
 *
 * OpenAPI spec version: 1.0.0-SNAPSHOT
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SwarmerServer.Models
{
    /// <summary>
    /// Full user model.
    /// </summary>
    public partial class User : UserInfo,  IEquatable<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        /// <param name="Id">Id of object..</param>
        /// <param name="Created">User creation time..</param>
        /// <param name="Updated">User info last modification time..</param>
        /// <param name="FirstName">First name of user..</param>
        /// <param name="SecondName">Second name of user..</param>
        /// <param name="Login">Login and nickname of user..</param>
        /// <param name="Gender">User&#39;s gender..</param>
        /// <param name="Role">Role of user..</param>
        /// <param name="AvailableEntries">Available entry ways..</param>
        /// <param name="SteamId">Id of user in Steam..</param>
        /// <param name="BirthDate">User birth date..</param>
        /// <param name="PhoneNumber">User&#39;s phone number..</param>
        /// <param name="Address">User&#39;s main address..</param>
        /// <param name="TimeZone">User&#39;s time zone for time correction..</param>
        /// <param name="Country">User&#39;s living country..</param>
        /// <param name="Profile">Profile.</param>
        public User(int? Id = null, DateTime? Created = null, DateTime? Updated = null, string FirstName = null, string SecondName = null, string Login = null, string Gender = null, string Role = null, List<string> AvailableEntries = null, int? SteamId = null, DateTime? BirthDate = null, string PhoneNumber = null, string Address = null, string TimeZone = null, string Country = null, UserProfile Profile = null)
        {
            this.Id = Id;
            this.Created = Created;
            this.Updated = Updated;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.Login = Login;
            this.Gender = Gender;
            this.Role = Role;
            this.AvailableEntries = AvailableEntries;
            this.SteamId = SteamId;
            this.BirthDate = BirthDate;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.TimeZone = TimeZone;
            this.Country = Country;
            this.Profile = Profile;
            
        }

        /// <summary>
        /// Id of object.
        /// </summary>
        /// <value>Id of object.</value>
        public int? Id { get; set; }

        /// <summary>
        /// User creation time.
        /// </summary>
        /// <value>User creation time.</value>
        public DateTime? Created { get; set; }

        /// <summary>
        /// User info last modification time.
        /// </summary>
        /// <value>User info last modification time.</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// First name of user.
        /// </summary>
        /// <value>First name of user.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Second name of user.
        /// </summary>
        /// <value>Second name of user.</value>
        public string SecondName { get; set; }

        /// <summary>
        /// Login and nickname of user.
        /// </summary>
        /// <value>Login and nickname of user.</value>
        public string Login { get; set; }

        /// <summary>
        /// User's gender.
        /// </summary>
        /// <value>User's gender.</value>
        public string Gender { get; set; }

        /// <summary>
        /// Role of user.
        /// </summary>
        /// <value>Role of user.</value>
        public string Role { get; set; }

        /// <summary>
        /// Available entry ways.
        /// </summary>
        /// <value>Available entry ways.</value>
        public List<string> AvailableEntries { get; set; }

        /// <summary>
        /// Id of user in Steam.
        /// </summary>
        /// <value>Id of user in Steam.</value>
        public int? SteamId { get; set; }

        /// <summary>
        /// User birth date.
        /// </summary>
        /// <value>User birth date.</value>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// User's phone number.
        /// </summary>
        /// <value>User's phone number.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// User's main address.
        /// </summary>
        /// <value>User's main address.</value>
        public string Address { get; set; }

        /// <summary>
        /// User's time zone for time correction.
        /// </summary>
        /// <value>User's time zone for time correction.</value>
        public string TimeZone { get; set; }

        /// <summary>
        /// User's living country.
        /// </summary>
        /// <value>User's living country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        public UserProfile Profile { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
sb.Append("  Created: ").Append(Created).Append("\n");
sb.Append("  Updated: ").Append(Updated).Append("\n");
sb.Append("  FirstName: ").Append(FirstName).Append("\n");
sb.Append("  SecondName: ").Append(SecondName).Append("\n");
sb.Append("  Login: ").Append(Login).Append("\n");
sb.Append("  Gender: ").Append(Gender).Append("\n");
sb.Append("  Role: ").Append(Role).Append("\n");
sb.Append("  AvailableEntries: ").Append(AvailableEntries).Append("\n");
sb.Append("  SteamId: ").Append(SteamId).Append("\n");
sb.Append("  BirthDate: ").Append(BirthDate).Append("\n");
sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
sb.Append("  Address: ").Append(Address).Append("\n");
sb.Append("  TimeZone: ").Append(TimeZone).Append("\n");
sb.Append("  Country: ").Append(Country).Append("\n");
sb.Append("  Profile: ").Append(Profile).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public  new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User)obj);
        }

        /// <summary>
        /// Returns true if User instances are equal
        /// </summary>
        /// <param name="other">Instance of User to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(User other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Created == other.Created ||
                    this.Created != null &&
                    this.Created.Equals(other.Created)
                ) && 
                (
                    this.Updated == other.Updated ||
                    this.Updated != null &&
                    this.Updated.Equals(other.Updated)
                ) && 
                (
                    this.FirstName == other.FirstName ||
                    this.FirstName != null &&
                    this.FirstName.Equals(other.FirstName)
                ) && 
                (
                    this.SecondName == other.SecondName ||
                    this.SecondName != null &&
                    this.SecondName.Equals(other.SecondName)
                ) && 
                (
                    this.Login == other.Login ||
                    this.Login != null &&
                    this.Login.Equals(other.Login)
                ) && 
                (
                    this.Gender == other.Gender ||
                    this.Gender != null &&
                    this.Gender.Equals(other.Gender)
                ) && 
                (
                    this.Role == other.Role ||
                    this.Role != null &&
                    this.Role.Equals(other.Role)
                ) && 
                (
                    this.AvailableEntries == other.AvailableEntries ||
                    this.AvailableEntries != null &&
                    this.AvailableEntries.SequenceEqual(other.AvailableEntries)
                ) && 
                (
                    this.SteamId == other.SteamId ||
                    this.SteamId != null &&
                    this.SteamId.Equals(other.SteamId)
                ) && 
                (
                    this.BirthDate == other.BirthDate ||
                    this.BirthDate != null &&
                    this.BirthDate.Equals(other.BirthDate)
                ) && 
                (
                    this.PhoneNumber == other.PhoneNumber ||
                    this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(other.PhoneNumber)
                ) && 
                (
                    this.Address == other.Address ||
                    this.Address != null &&
                    this.Address.Equals(other.Address)
                ) && 
                (
                    this.TimeZone == other.TimeZone ||
                    this.TimeZone != null &&
                    this.TimeZone.Equals(other.TimeZone)
                ) && 
                (
                    this.Country == other.Country ||
                    this.Country != null &&
                    this.Country.Equals(other.Country)
                ) && 
                (
                    this.Profile == other.Profile ||
                    this.Profile != null &&
                    this.Profile.Equals(other.Profile)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                    if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                    if (this.Created != null)
                    hash = hash * 59 + this.Created.GetHashCode();
                    if (this.Updated != null)
                    hash = hash * 59 + this.Updated.GetHashCode();
                    if (this.FirstName != null)
                    hash = hash * 59 + this.FirstName.GetHashCode();
                    if (this.SecondName != null)
                    hash = hash * 59 + this.SecondName.GetHashCode();
                    if (this.Login != null)
                    hash = hash * 59 + this.Login.GetHashCode();
                    if (this.Gender != null)
                    hash = hash * 59 + this.Gender.GetHashCode();
                    if (this.Role != null)
                    hash = hash * 59 + this.Role.GetHashCode();
                    if (this.AvailableEntries != null)
                    hash = hash * 59 + this.AvailableEntries.GetHashCode();
                    if (this.SteamId != null)
                    hash = hash * 59 + this.SteamId.GetHashCode();
                    if (this.BirthDate != null)
                    hash = hash * 59 + this.BirthDate.GetHashCode();
                    if (this.PhoneNumber != null)
                    hash = hash * 59 + this.PhoneNumber.GetHashCode();
                    if (this.Address != null)
                    hash = hash * 59 + this.Address.GetHashCode();
                    if (this.TimeZone != null)
                    hash = hash * 59 + this.TimeZone.GetHashCode();
                    if (this.Country != null)
                    hash = hash * 59 + this.Country.GetHashCode();
                    if (this.Profile != null)
                    hash = hash * 59 + this.Profile.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(User left, User right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
