using Models;
using Models.Enums;
using Models.TrainingModel;
using Models.UserModel;
using Newtonsoft.Json;

namespace DataAccess
{
    public class Storage
    {
        public StorageSet<User> Users { get; set; }
        public StorageSet<Trainer> Trainers { get; set; }
        public StorageSet<Training> Trainings { get; set; }
        public List<BaseEntity> BaseEntities { get; set; }

        public Storage()
        {
            Users = new StorageSet<User>();
            Trainers = new StorageSet<Trainer>();
            Trainings = new StorageSet<Training>();
            BaseEntities = new List<BaseEntity>();

            // Add all users to BaseEntities
            foreach (var user in Users.GetAll())
            {
                BaseEntities.Add(user);
            }

            // Add all trainers to BaseEntities
            foreach (var trainer in Trainers.GetAll())
            {
                BaseEntities.Add(trainer);
            }

            if (!Users.GetAll().Any())
            {
                //JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                Users.Add(new User(0, "Dino", "Nikolovski", "dino" , "12345.dino", AccountTypeEnum.StandardUser));
                
                //string json = JsonConvert.SerializeObject(Users.GetAll());

                // Deserialize JSON back to a collection of User objects
                //var deserializedUsers = JsonConvert.DeserializeObject<List<User>>(json);
            }

            if (!Trainers.GetAll().Any())
            {
                Trainers.Add(new Trainer(0, "Test", "TestLN", "test", "12345test", new List<User>(Users.GetAll())));
            }
        }
    }
}
