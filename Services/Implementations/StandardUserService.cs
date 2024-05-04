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
        public void Account(int id)
        {
            throw new NotImplementedException();
        }

        public void Upgrade()//int id)
        {
            //var user = _storage.Users.GetById(id);
            //OR
            var user = _storage.Users.GetById(CurrentSession.CurrentUser.Id);
            if (user.AccountType == AccountTypeEnum.PremiumUser)
            {
                throw new Exception("You are already a premium user");
            }

            user.AccountType = AccountTypeEnum.PremiumUser;
            _storage.Users.Update(user);
            CurrentSession.CurrentUser = user;
        }
    }
}
