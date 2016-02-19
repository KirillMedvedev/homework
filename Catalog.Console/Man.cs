namespace Catalog.Console
{
    public class Man
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
}
