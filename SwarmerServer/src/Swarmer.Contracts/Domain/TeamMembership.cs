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
using System.Text;
using Newtonsoft.Json;

namespace Swarmer.AM.Contracts.Domain
{
    /// <summary>
    /// User team membership
    /// </summary>
    public partial class TeamMembership : SysObject, IEquatable<TeamMembership>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMembership" /> class.
        /// </summary>
        public TeamMembership()
	    {
		    
	    }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMembership" /> class.
        /// </summary>
        /// <param name="Id">Id of object..</param>
        /// <param name="Created">Creationg date time.</param>
        /// <param name="Updated">Updating date time..</param>
        /// <param name="UserId">Id of user that participate in team.</param>
        /// <param name="TeamId">Id of team in which user participate.</param>
        /// <param name="Data">Data.</param>
        public TeamMembership(Guid? Id = null, 
            DateTime? Created = null, 
            DateTime? Updated = null, 
            Guid? UserId = null, 
            Guid? TeamId = null, 
            TeamMembershipData Data = null)
        {
            this.Id = Id;
            this.Created = Created;
            this.Updated = Updated;
            this.UserId = UserId;
            this.TeamId = TeamId;
            this.Data = Data;
        }

        /// <summary>
        /// Id of user that participate in team
        /// </summary>
        /// <value>Id of user that participate in team</value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Id of team in which user participate
        /// </summary>
        /// <value>Id of team in which user participate</value>
        public Guid? TeamId { get; set; }

        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        public TeamMembershipData Data { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TeamMembership {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  TeamId: ").Append(TeamId).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
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
            return Equals((TeamMembership)obj);
        }

        /// <summary>
        /// Returns true if TeamMembership instances are equal
        /// </summary>
        /// <param name="other">Instance of TeamMembership to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TeamMembership other)
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
                    this.UserId == other.UserId ||
                    this.UserId != null &&
                    this.UserId.Equals(other.UserId)
                ) &&
                (
                    this.TeamId == other.TeamId ||
                    this.TeamId != null &&
                    this.TeamId.Equals(other.TeamId)
                ) &&
                (
                    this.Data == other.Data ||
                    this.Data != null &&
                    this.Data.Equals(other.Data)
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
                if (this.UserId != null)
                    hash = hash * 59 + this.UserId.GetHashCode();
                if (this.TeamId != null)
                    hash = hash * 59 + this.TeamId.GetHashCode();
                if (this.Data != null)
                    hash = hash * 59 + this.Data.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(TeamMembership left, TeamMembership right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamMembership left, TeamMembership right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
