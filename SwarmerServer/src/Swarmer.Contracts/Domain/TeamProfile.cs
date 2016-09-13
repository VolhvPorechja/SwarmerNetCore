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
    /// Profile of team.
    /// </summary>
    public partial class TeamProfile : IEquatable<TeamProfile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamProfile" /> class.
        /// </summary>
        /// <param name="Icon">Link to icon of team..</param>
        /// <param name="Image">Link to image of team..</param>
        /// <param name="NumberOfWins">Number of team wins..</param>
        /// <param name="TotalGames">Total number of games..</param>
        public TeamProfile(string Icon = null, string Image = null, int? NumberOfWins = null, int? TotalGames = null)
        {
            this.Icon = Icon;
            this.Image = Image;
            this.NumberOfWins = NumberOfWins;
            this.TotalGames = TotalGames;

        }

        /// <summary>
        /// Link to icon of team.
        /// </summary>
        /// <value>Link to icon of team.</value>
        public string Icon { get; set; }

        /// <summary>
        /// Link to image of team.
        /// </summary>
        /// <value>Link to image of team.</value>
        public string Image { get; set; }

        /// <summary>
        /// Number of team wins.
        /// </summary>
        /// <value>Number of team wins.</value>
        public int? NumberOfWins { get; set; }

        /// <summary>
        /// Total number of games.
        /// </summary>
        /// <value>Total number of games.</value>
        public int? TotalGames { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TeamProfile {\n");
            sb.Append("  Icon: ").Append(Icon).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  NumberOfWins: ").Append(NumberOfWins).Append("\n");
            sb.Append("  TotalGames: ").Append(TotalGames).Append("\n");
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
            return Equals((TeamProfile)obj);
        }

        /// <summary>
        /// Returns true if TeamProfile instances are equal
        /// </summary>
        /// <param name="other">Instance of TeamProfile to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TeamProfile other)
        {

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    this.Icon == other.Icon ||
                    this.Icon != null &&
                    this.Icon.Equals(other.Icon)
                ) &&
                (
                    this.Image == other.Image ||
                    this.Image != null &&
                    this.Image.Equals(other.Image)
                ) &&
                (
                    this.NumberOfWins == other.NumberOfWins ||
                    this.NumberOfWins != null &&
                    this.NumberOfWins.Equals(other.NumberOfWins)
                ) &&
                (
                    this.TotalGames == other.TotalGames ||
                    this.TotalGames != null &&
                    this.TotalGames.Equals(other.TotalGames)
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
                if (this.Icon != null)
                    hash = hash * 59 + this.Icon.GetHashCode();
                if (this.Image != null)
                    hash = hash * 59 + this.Image.GetHashCode();
                if (this.NumberOfWins != null)
                    hash = hash * 59 + this.NumberOfWins.GetHashCode();
                if (this.TotalGames != null)
                    hash = hash * 59 + this.TotalGames.GetHashCode();
                return hash;
            }
        }

        #region Operators

        public static bool operator ==(TeamProfile left, TeamProfile right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TeamProfile left, TeamProfile right)
        {
            return !Equals(left, right);
        }

        #endregion Operators

    }
}
