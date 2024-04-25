using Models.Enums;

namespace Models.UserModel
{
    public class User : Person
    {
        public AccountTypeEnum AccountType { get; set; }
        public User(int id, string firstName, string lastName, string username, string password, AccountTypeEnum accountType)
            : base(id, firstName, lastName, username, password)
        {
            AccountType = accountType;
        }
    }
}
