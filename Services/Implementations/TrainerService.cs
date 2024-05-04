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
            var loginTrainer = _storage.Trainers.GetAll().FirstOrDefault(x => x.Username == username);

            if (loginTrainer == null)
                throw new Exception("Non existing user!");

            if (!loginTrainer.CheckPassword(password))
            {
                throw new Exception("Wrong password");
            }

            CurrentSession.CurrentTrainer = loginTrainer;
        }

        public void LogOut()
        {
            CurrentSession.CurrentTrainer = null;
        }
    }
}
