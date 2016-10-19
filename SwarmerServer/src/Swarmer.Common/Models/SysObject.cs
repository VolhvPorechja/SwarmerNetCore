using System;
using System.Text;
using Newtonsoft.Json;

namespace Swarmer.Common.Models
{
    /// <summary>
    /// System information about object
    /// </summary>
    public abstract class SysObject : IEquatable<SysObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SysObject" /> class.
        /// </summary>
        /// <param name="id">Id of object..</param>
        /// <param name="created">Creationg date time.</param>
        /// <param name="updated">Updating date time..</param>
        protected SysObject(Guid? id = null, DateTime? created = null, DateTime? updated = null)
        {
            Id = id;
            Created = created;
            Updated = updated;
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
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Created == other.Created ||
                    Created != null &&
                    Created.Equals(other.Created)
                ) &&
                (
                    Updated == other.Updated ||
                    Updated != null &&
                    Updated.Equals(other.Updated)
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
                if (Id != null)
                    hash = hash * 59 + Id.GetHashCode();
                if (Created != null)
                    hash = hash * 59 + Created.GetHashCode();
                if (Updated != null)
                    hash = hash * 59 + Updated.GetHashCode();
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
