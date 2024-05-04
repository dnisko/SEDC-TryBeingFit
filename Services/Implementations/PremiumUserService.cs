using DataAccess;
using Services.Interfaces;

namespace Services.Implementations
{
    public class PremiumUserService : IPremiumUserService
    {
        private Storage _storage;

        public PremiumUserService()
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

        public void Train()
        {
            throw new NotImplementedException();
        }

        public void Account(int id)
        {
            throw new NotImplementedException();
        }
    }
}
