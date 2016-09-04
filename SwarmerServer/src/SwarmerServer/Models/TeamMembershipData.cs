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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
    /// <summary>
    /// Info about user team perticipation.
    /// </summary>
    public partial class TeamMembershipData :  IEquatable<TeamMembershipData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMembershipData" /> class.
        /// </summary>
        /// <param name="Approuved">Is user participation approuved by owner.</param>
        /// <param name="IsActive">Is user participation in team is active.</param>
        /// <param name="StartDate">When user membership started..</param>
        public TeamMembershipData(bool? Approuved = null, bool? IsActive = null, DateTime? StartDate = null)
        {
            this.Approuved = Approuved;
            this.IsActive = IsActive;
            this.StartDate = StartDate;
            
        }

        /// <summary>
        /// Is user participation approuved by owner
        /// </summary>
        /// <value>Is user participation approuved by owner</value>
        public bool? Approuved { get; set; }

        /// <summary>
        /// Is user participation in team is active
        /// </summary>
        /// <value>Is user participation in team is active</value>
        public bool? IsActive { get; set; }

        /// <summary>
        /// When user membership started.
        /// </summary>
        /// <value>When user membership started.</value>
        public DateTime? StartDate { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TeamMembershipData {\n");
            sb.Append("  Approuved: ").Append(Approuved).Append("\n");
sb.Append("  IsActive: ").Append(IsActive).Append("\n");
sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
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
            return Equals((TeamMembershipData)obj);
        }

        /// <summary>
        /// Returns true if TeamMembershipData instances are equal
        /// </summary>
        /// <param name="other">Instance of TeamMembershipData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TeamMembershipData other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.Approuved == other.Approuved ||
                    this.Approuved != null &&
                    this.Approuved.Equals(other.Approuved)
                ) && 
                (
                    this.IsActive == other.IsActive ||
                    this.IsActive != null &&
                    this.IsActive.Equals(other.IsActive)
                ) && 
                (
                    this.StartDate == other.StartDate ||
                    this.StartDate != null &&
                    this.StartDate.Equals(other.StartDate)
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
                    if (this.Approuved != null)
                    hash = hash * 59 + this.Approuved.GetHashCode();
                    if (this.IsActive != null)
                    hash = hash * 59 + this.IsActive.GetHashCode();
                    if (this.StartDate != null)
                    hash = hash * 59 + this.StartDate.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(TeamMembershipData left, TeamMembershipData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamMembershipData left, TeamMembershipData right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
