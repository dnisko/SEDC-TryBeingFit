namespace Services.Interfaces
{
    /*
     Premium should have a menu:

       Train, Account and Log Out 
     */
    public interface IPremiumUserService
    {
        void Login(string username, string password);
        void LogOut();
        void Train();
        void Account(int id);
    }
}
