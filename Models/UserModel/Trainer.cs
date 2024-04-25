namespace Models.UserModel
{
    public class Trainer : Person
    {
        public List<User> TrainedUsers { get; set; }
        public Trainer(int id, string firstName, string lastName, string username, string password, List<User> trainedUsers)
            : base(id, firstName, lastName, username, password)
        {
            TrainedUsers = trainedUsers;
        }
    }
}
