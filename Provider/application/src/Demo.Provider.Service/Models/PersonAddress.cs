/*
 * API for Demo
 *
 * # Goal This API Description is used as the basis to show code generating use-cases.   <SecurityDefinitions />
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Demo.Provider.Service.Converters;

namespace Demo.Provider.Service.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PersonAddress : IEquatable<PersonAddress>
    {
        /// <summary>
        /// Gets or Sets Street
        /// </summary>
        /// <example>&quot;Evergreen Terace&quot;</example>
        [StringLength(128, MinimumLength=1)]
        [DataMember(Name="street", EmitDefaultValue=false)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or Sets HouseNumber
        /// </summary>
        /// <example>&quot;7a&quot;</example>
        [StringLength(10, MinimumLength=1)]
        [DataMember(Name="houseNumber", EmitDefaultValue=false)]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or Sets PostalCode
        /// </summary>
        /// <example>&quot;1234&quot;</example>
        [StringLength(10, MinimumLength=1)]
        [DataMember(Name="postalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        /// <example>&quot;Springfield&quot;</example>
        [StringLength(128, MinimumLength=1)]
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PersonAddress {\n");
            sb.Append("  Street: ").Append(Street).Append("\n");
            sb.Append("  HouseNumber: ").Append(HouseNumber).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((PersonAddress)obj);
        }

        /// <summary>
        /// Returns true if PersonAddress instances are equal
        /// </summary>
        /// <param name="other">Instance of PersonAddress to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PersonAddress other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Street == other.Street ||
                    Street != null &&
                    Street.Equals(other.Street)
                ) && 
                (
                    HouseNumber == other.HouseNumber ||
                    HouseNumber != null &&
                    HouseNumber.Equals(other.HouseNumber)
                ) && 
                (
                    PostalCode == other.PostalCode ||
                    PostalCode != null &&
                    PostalCode.Equals(other.PostalCode)
                ) && 
                (
                    City == other.City ||
                    City != null &&
                    City.Equals(other.City)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Street != null)
                    hashCode = hashCode * 59 + Street.GetHashCode();
                    if (HouseNumber != null)
                    hashCode = hashCode * 59 + HouseNumber.GetHashCode();
                    if (PostalCode != null)
                    hashCode = hashCode * 59 + PostalCode.GetHashCode();
                    if (City != null)
                    hashCode = hashCode * 59 + City.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PersonAddress left, PersonAddress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PersonAddress left, PersonAddress right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}