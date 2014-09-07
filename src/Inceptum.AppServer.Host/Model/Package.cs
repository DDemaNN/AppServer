using System;

namespace Inceptum.AppServer.Host.Model
{
    public class Package
    {
        public bool Debug { get; set; }
        public string Vendor { get; set; }
        public string Description { get; set; }
        public string PackageId { get; set; }
        public Version Version { get; set; }

        protected bool Equals(Package other)
        {
            return string.Equals(Vendor, other.Vendor) && string.Equals(Description, other.Description) && string.Equals(PackageId, other.PackageId) && Equals(Version, other.Version);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Package)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Vendor != null ? Vendor.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PackageId != null ? PackageId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Version != null ? Version.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Package left, Package right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Package left, Package right)
        {
            return !Equals(left, right);
        } 
    }
}