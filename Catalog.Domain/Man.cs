using System;

namespace Catalog.Domain
{
    public partial class Man
    {
        public Man(string lastName, string name, string gender, string favoriteColor, DateTime birthdate)
        {
            LastName = lastName;
            Name = name;
            Gender = gender;
            FavoriteColor = favoriteColor;
            Birthdate = birthdate;
        }

        public string LastName { get; }
        public string Name { get; }
        public string Gender { get; }
        public DateTime Birthdate { get; }
        public string FavoriteColor { get; }

        public override string ToString()
        {
            return string.Format("{0} {1}, born in {2}, loves {3} color, is a {4}", Name, LastName, Birthdate.ToString("M/d/yyyy"), FavoriteColor, Gender);
        }
    }


    public partial class Man
    {
        protected bool Equals(Man other)
        {
            return string.Equals(LastName, other.LastName) && string.Equals(Name, other.Name) && string.Equals(Gender, other.Gender) && Birthdate.Equals(other.Birthdate) && string.Equals(FavoriteColor, other.FavoriteColor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Man) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Gender != null ? Gender.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Birthdate.GetHashCode();
                hashCode = (hashCode*397) ^ (FavoriteColor != null ? FavoriteColor.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
