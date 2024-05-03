namespace Services.Interfaces
{
    /*
     Reschedule training, Account, Train and Log Out
     */
    public interface ITrainerService
    {
        public void RescheduleTraining();
        public void Account();
        public void Train();
        public void LogIn(string username, string password);
        public void LogOut();
    }
}
