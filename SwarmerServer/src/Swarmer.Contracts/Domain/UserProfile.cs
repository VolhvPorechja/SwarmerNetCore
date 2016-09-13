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
    /// 
    /// </summary>
    public partial class UserProfile :  IEquatable<UserProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile" /> class.
        /// </summary>
        /// <param name="Image">Link on user image..</param>
        /// <param name="LastName">Last name of the Uber user..</param>
        public UserProfile(string Image = null, string LastName = null)
        {
            this.Image = Image;
            this.LastName = LastName;
            
        }

        /// <summary>
        /// Link on user image.
        /// </summary>
        /// <value>Link on user image.</value>
        public string Image { get; set; }

        /// <summary>
        /// Last name of the Uber user.
        /// </summary>
        /// <value>Last name of the Uber user.</value>
        public string LastName { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserProfile {\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
sb.Append("  LastName: ").Append(LastName).Append("\n");
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
            return Equals((UserProfile)obj);
        }

        /// <summary>
        /// Returns true if UserProfile instances are equal
        /// </summary>
        /// <param name="other">Instance of UserProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserProfile other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    this.Image == other.Image ||
                    this.Image != null &&
                    this.Image.Equals(other.Image)
                ) && 
                (
                    this.LastName == other.LastName ||
                    this.LastName != null &&
                    this.LastName.Equals(other.LastName)
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
                    if (this.Image != null)
                    hash = hash * 59 + this.Image.GetHashCode();
                    if (this.LastName != null)
                    hash = hash * 59 + this.LastName.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(UserProfile left, UserProfile right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserProfile left, UserProfile right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
