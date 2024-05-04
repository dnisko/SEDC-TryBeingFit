namespace Models.UserModel
{
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Person(int id, string firstName, string lastName, string username, string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            SetPassword(password);
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is required");
            }

            if (password.Length < 8)
            {
                throw new ArgumentException("Password length needs to be at least 8 chars");
            }

            Password = password;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
    }
}
