using DataAccess;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private Storage _storage;

        public TrainerService()
        {
            _storage = new Storage();
        }
        //remove from 1 day to another..
        public void RescheduleTraining()
        {
            throw new NotImplementedException();
        }
        //stats
        public void Account()
        {
            throw new NotImplementedException();
        }
        //train people...
        public void Train()
        {
            throw new NotImplementedException();
        }

        public void LogIn(string username, string password)
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
    }
}
