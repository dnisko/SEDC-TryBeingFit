using Models.Enums;
using Models.TrainingModel;
using Models.UserModel;

namespace DataAccess
{
    internal class Storage
    {
        public static StorageSet<User> Users { get; set; } = new StorageSet<User>()
        {
            Items = new List<User>() { new User(1, "dino", "nikolovski", "dinko", "asde", AccountTypeEnum.StandardUser)}
        };

        public static StorageSet<Trainer> Trainers { get; set; } = new StorageSet<Trainer>();
        public static StorageSet<Training> Trainings { get; set; } = new StorageSet<Training>();
    }
}
