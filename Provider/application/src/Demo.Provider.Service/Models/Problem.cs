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
    /// This object represents a problem and is structured after [RFC7807]
    /// </summary>
    [DataContract]
    public partial class Problem : IEquatable<Problem>
    {
        /// <summary>
        /// A absolute URI reference [RFC 3986] that identifies the problem type. 
        /// </summary>
        /// <value>A absolute URI reference [RFC 3986] that identifies the problem type. </value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; } = "about:blank";

        /// <summary>
        /// A short, human-readable summary of the problem type. 
        /// </summary>
        /// <value>A short, human-readable summary of the problem type. </value>
        /// <example>&quot;Not Found&quot;</example>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// The HTTP status code generated by the origin server for this occurrence of the problem. 
        /// </summary>
        /// <value>The HTTP status code generated by the origin server for this occurrence of the problem. </value>
        /// <example>404</example>
        [Range(100, 600)]
        [DataMember(Name="status", EmitDefaultValue=true)]
        public int Status { get; set; }

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem. 
        /// </summary>
        /// <value>A human-readable explanation specific to this occurrence of the problem. </value>
        /// <example>&quot;The requested resource could not be found.&quot;</example>
        [DataMember(Name="detail", EmitDefaultValue=false)]
        public string Detail { get; set; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem.  It may or may not yield further information if dereferenced. 
        /// </summary>
        /// <value>A URI reference that identifies the specific occurrence of the problem.  It may or may not yield further information if dereferenced. </value>
        [DataMember(Name="instance", EmitDefaultValue=false)]
        public string Instance { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Problem {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Detail: ").Append(Detail).Append("\n");
            sb.Append("  Instance: ").Append(Instance).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Problem)obj);
        }

        /// <summary>
        /// Returns true if Problem instances are equal
        /// </summary>
        /// <param name="other">Instance of Problem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Problem other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    Status == other.Status ||
                    
                    Status.Equals(other.Status)
                ) && 
                (
                    Detail == other.Detail ||
                    Detail != null &&
                    Detail.Equals(other.Detail)
                ) && 
                (
                    Instance == other.Instance ||
                    Instance != null &&
                    Instance.Equals(other.Instance)
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
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                    if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                    
                    hashCode = hashCode * 59 + Status.GetHashCode();
                    if (Detail != null)
                    hashCode = hashCode * 59 + Detail.GetHashCode();
                    if (Instance != null)
                    hashCode = hashCode * 59 + Instance.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Problem left, Problem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Problem left, Problem right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
