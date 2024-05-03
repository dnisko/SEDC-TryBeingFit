using Services.Interfaces;
using DataAccess;
using Models.Enums;

namespace Services.Implementations
{
    public class StandardUserService : IStandardUserService
    {
        private Storage _storage;

        public StandardUserService()
        {
            _storage = new Storage();
        }
        public void Login(string username, string password)
        {
            var loginUser = _storage.Users.GetAll().FirstOrDefault(x => x.Username == username);

            if (loginUser == null)
                throw new Exception("Non existing user!");

            if (!loginUser.CheckPassword(password))
            {
                throw new Exception("Wrong password");
            }

            CurrentSession.CurrentUser = loginUser;
        }

        public void LogOut()
        {
            CurrentSession.CurrentUser = null;
        }
        //what to do here?!
        public void Train()
        {
            throw new NotImplementedException();
        }
        //see stats??
        public void Account()
        {
            throw new NotImplementedException();
        }

        public void Upgrade(int id)
        {
            CurrentSession.CurrentUser.AccountType = AccountTypeEnum.PremiumUser;
        }
    }
}
