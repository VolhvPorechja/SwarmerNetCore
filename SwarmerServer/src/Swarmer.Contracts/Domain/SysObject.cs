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
    /// System information about object
    /// </summary>
    public partial class SysObject :  IEquatable<SysObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysObject" /> class.
        /// </summary>
        /// <param name="Id">Id of object..</param>
        /// <param name="Created">Creationg date time.</param>
        /// <param name="Updated">Updating date time..</param>
        public SysObject(Guid? Id = null, DateTime? Created = null, DateTime? Updated = null)
        {
            this.Id = Id;
            this.Created = Created;
            this.Updated = Updated;
            
        }

        /// <summary>
        /// Id of object.
        /// </summary>
        /// <value>Id of object.</value>
        public Guid? Id { get; set; }

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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SysObject {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
sb.Append("  Created: ").Append(Created).Append("\n");
sb.Append("  Updated: ").Append(Updated).Append("\n");
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
            return Equals((SysObject)obj);
        }

        /// <summary>
        /// Returns true if SysObject instances are equal
        /// </summary>
        /// <param name="other">Instance of SysObject to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SysObject other)
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
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(SysObject left, SysObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SysObject left, SysObject right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
