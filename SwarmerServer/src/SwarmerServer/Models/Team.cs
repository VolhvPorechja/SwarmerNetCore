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
    /// Full model of team.
    /// </summary>
    public partial class Team : TeamInfo,  IEquatable<Team>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Team" /> class.
        /// </summary>
        /// <param name="Id">Id of object..</param>
        /// <param name="Created">Creationg date time.</param>
        /// <param name="Updated">Updating date time..</param>
        /// <param name="Name">Name of team..</param>
        /// <param name="Owner">Id of owning user..</param>
        /// <param name="FullName">Full name of team..</param>
        /// <param name="Profile">Profile.</param>
        /// <param name="Members">Members.</param>
        public Team(int? Id = null, DateTime? Created = null, DateTime? Updated = null, string Name = null, int? Owner = null, string FullName = null, TeamProfile Profile = null, List<TeamMembership> Members = null)
        {
            this.Id = Id;
            this.Created = Created;
            this.Updated = Updated;
            this.Name = Name;
            this.Owner = Owner;
            this.FullName = FullName;
            this.Profile = Profile;
            this.Members = Members;
            
        }

        /// <summary>
        /// Id of object.
        /// </summary>
        /// <value>Id of object.</value>
        public int? Id { get; set; }

        /// <summary>
        /// Creationg date time
        /// </summary>
        /// <value>Creationg date time</value>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Updating date time.
        /// </summary>
        /// <value>Updating date time.</value>
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Name of team.
        /// </summary>
        /// <value>Name of team.</value>
        public string Name { get; set; }

        /// <summary>
        /// Id of owning user.
        /// </summary>
        /// <value>Id of owning user.</value>
        public int? Owner { get; set; }

        /// <summary>
        /// Full name of team.
        /// </summary>
        /// <value>Full name of team.</value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or Sets Profile
        /// </summary>
        public TeamProfile Profile { get; set; }

        /// <summary>
        /// Gets or Sets Members
        /// </summary>
        public List<TeamMembership> Members { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Team {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
sb.Append("  Created: ").Append(Created).Append("\n");
sb.Append("  Updated: ").Append(Updated).Append("\n");
sb.Append("  Name: ").Append(Name).Append("\n");
sb.Append("  Owner: ").Append(Owner).Append("\n");
sb.Append("  FullName: ").Append(FullName).Append("\n");
sb.Append("  Profile: ").Append(Profile).Append("\n");
sb.Append("  Members: ").Append(Members).Append("\n");
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
            return Equals((Team)obj);
        }

        /// <summary>
        /// Returns true if Team instances are equal
        /// </summary>
        /// <param name="other">Instance of Team to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Team other)
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
                    this.Name == other.Name ||
                    this.Name != null &&
                    this.Name.Equals(other.Name)
                ) && 
                (
                    this.Owner == other.Owner ||
                    this.Owner != null &&
                    this.Owner.Equals(other.Owner)
                ) && 
                (
                    this.FullName == other.FullName ||
                    this.FullName != null &&
                    this.FullName.Equals(other.FullName)
                ) && 
                (
                    this.Profile == other.Profile ||
                    this.Profile != null &&
                    this.Profile.Equals(other.Profile)
                ) && 
                (
                    this.Members == other.Members ||
                    this.Members != null &&
                    this.Members.SequenceEqual(other.Members)
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
                    if (this.Name != null)
                    hash = hash * 59 + this.Name.GetHashCode();
                    if (this.Owner != null)
                    hash = hash * 59 + this.Owner.GetHashCode();
                    if (this.FullName != null)
                    hash = hash * 59 + this.FullName.GetHashCode();
                    if (this.Profile != null)
                    hash = hash * 59 + this.Profile.GetHashCode();
                    if (this.Members != null)
                    hash = hash * 59 + this.Members.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(Team left, Team right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Team left, Team right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
