namespace Catalog.Domain
{
    public partial class Man
    {
        public Man(string lastName, string name, string gender, string favoriteColor, string birthday)
        {
            LastName = lastName;
            Name = name;
            Gender = gender;
            FavoriteColor = favoriteColor;
            Birthday = birthday;
        }

        public string LastName { get; }
        public string Name { get; }
        public string Gender { get; }
        public string Birthday { get; }
        public string FavoriteColor { get; }

        public override string ToString()
        {
            return string.Format("{0} {1}, born in {2}, loves {3} color, is a {4}", Name, LastName, Birthday, FavoriteColor, Gender);
        }
    }


    public partial class Man
    {
        protected bool Equals(Man other)
        {
            return string.Equals(LastName, other.LastName) && string.Equals(Name, other.Name) && string.Equals(Gender, other.Gender) && string.Equals(Birthday, other.Birthday) && string.Equals(FavoriteColor, other.FavoriteColor);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Man)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Gender != null ? Gender.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Birthday != null ? Birthday.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FavoriteColor != null ? FavoriteColor.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
