using DataAccess;
using Models;
using Models.Enums;
using Models.UserModel;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UIService : IUIService
    {
        private IPremiumUserService _premiumUserService;
        private IStandardUserService _standardUserService;
        private ITrainerService _trainerService;
        private ITrainingService _trainingService;
        //private 
        private Storage _storage;
        private User _loggedUser;
        private Trainer _loggedTrainer;

        //private Type CurrentSessionType;
        public UIService()
        {
            _premiumUserService = new PremiumUserService();
            _standardUserService = new StandardUserService();
            _trainerService = new TrainerService();
            _trainingService = new TrainingService();
            _storage = new Storage();
        }
        public void Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please login!");
                    Console.Write("Username: ");
                    var username = Console.ReadLine();

                    Console.Write("Password: ");
                    var password = Console.ReadLine();

                    _loggedUser = _storage.Users.GetAll().FirstOrDefault(x => x.Username == username);
                    _loggedTrainer = _storage.Trainers.GetAll().FirstOrDefault(x => x.Username == username);

                    if (_loggedUser != null)
                    {
                        if (_loggedUser.AccountType == AccountTypeEnum.PremiumUser)
                        {
                            _premiumUserService.Login(username, password);
                        }
                        else
                        {
                            _standardUserService.Login(username, password);
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Successful Login! Welcome {CurrentSession.CurrentUser.FirstName} [{CurrentSession.CurrentUser.AccountType}]");
                        Console.ForegroundColor = ConsoleColor.White;
                        //_user = CurrentSession.CurrentUser;
                        //CurrentSessionType = CurrentSession.CurrentUser.GetType();
                        break;
                    }

                    if (_loggedTrainer != null)
                    {
                        _trainerService.LogIn(username, password);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(
                            $"Successful Login! Welcome [Trainer] {CurrentSession.CurrentTrainer.FirstName}");
                        Console.ForegroundColor = ConsoleColor.White;
                        //_user = CurrentSession.CurrentUser;
                        //CurrentSessionType = CurrentSession.CurrentTrainer.GetType();
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Please try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public void LogOut()
        {
            Console.WriteLine("Thank you for using our app");
            if (_loggedTrainer != null)
            {
                _trainerService.LogOut();
            }

            if (_loggedUser != null)
            {
                if (CurrentSession.CurrentUser.AccountType == AccountTypeEnum.PremiumUser)
                {
                    _premiumUserService.LogOut();
                }
                else
                {
                    _standardUserService.LogOut();
                }
            }

            //if (CurrentSessionType is User)
            //{
            //    if (CurrentSession.CurrentUser.AccountType == AccountTypeEnum.PremiumUser)
            //    {
            //        _premiumUserService.LogOut();
            //    }
            //    else
            //    {
            //        _standardUserService.LogOut();
            //    }
            //}
            //else
            //{
            //    _trainerService.LogOut();
            //}
            //_premiumUserService.LogOut();
            //_standardUserService.LogOut();
            //trainerService.LogOut();
        }
        public void ShowMenu()
        {
            if (CurrentSession.CurrentUser == null && CurrentSession.CurrentTrainer == null)
            {
                Login();
                return;
            }

            Console.WriteLine("Please select option from the menu: ");
            if(_loggedUser != null)//if (CurrentSessionType == typeof(User))
            {
                //person = (User)CurrentSession.CurrentUser;
                switch (CurrentSession.CurrentUser.AccountType)
                {
                    case AccountTypeEnum.PremiumUser:
                        ShowPremiumMenu();
                        break;
                    default: //AccountTypeEnum.StandardUser:
                        ShowStandardMenu();
                        break;
                }
            }

            //if (CurrentSession.CurrentUser is Trainer)
            if(_loggedTrainer != null)//if (CurrentSessionType == typeof(Trainer))
            {
                //baseEntity = (Trainer)CurrentSession.CurrentUser;
                ShowTrainerMenu();
            }
        }

        #region Standard Menu
        public void ShowStandardMenu()
        {
            //Train, Upgrade to premium, Account and Log Out;

            Console.WriteLine("1. Train.");
            Console.WriteLine("2. Account.");
            Console.WriteLine("3. Upgrade to premium.");
            Console.WriteLine("4. Log Out.");


            int option = ChooseAnOption(1, 4);
            //var user = CurrentSession.CurrentUser.GetType();
            _storage.BaseEntities.FirstOrDefault(x => x.Id == CurrentSession.CurrentUser.Id);
            switch (option)
            {
                case 1:
                    Train();
                    break;
                case 2:
                    Account();
                    break;
                case 3:
                    Upgrade();
                    break;
                case 4:
                    LogOut();//_standardUserService.LogOut();
                    break;
            }
        }

        #region Premium Menu

        public void ShowPremiumMenu()
        {
            //Train, Account and Log Out;

            Console.WriteLine("1. Train.");
            Console.WriteLine("2. Account.");
            Console.WriteLine("3. Log Out.");


            int option = ChooseAnOption(1, 3);
            //var user = CurrentSession.CurrentUser.GetType();
            _storage.BaseEntities.FirstOrDefault(x => x.Id == CurrentSession.CurrentUser.Id);
            switch (option)
            {
                case 1:
                    Train();
                    break;
                case 2:
                    Account();
                    break;
                case 3:
                    LogOut();//_premiumUserService.LogOut();
                    break;
            }
        }
        #endregion

        public void Upgrade()
        {
            _standardUserService.Upgrade();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successful Upgrade! Welcome to Premium Users {CurrentSession.CurrentUser.FirstName} [{CurrentSession.CurrentUser.AccountType}]");
            Console.ForegroundColor = ConsoleColor.White;
            //_user = CurrentSession.CurrentUser;
        }
        #endregion

        public void Train()
        {
            
        }

        public void Account()
        {
            var loggedUser = CurrentSession.CurrentUser;
            var loggedTrainer = CurrentSession.CurrentTrainer;
            //if (CurrentSessionType == typeof(User))
            if(_loggedUser != null)
            {
                //(User)loggedUser;
                switch (loggedUser.AccountType)
                {
                    case AccountTypeEnum.StandardUser:
                        Console.WriteLine();
                        break;
                    case AccountTypeEnum.PremiumUser:
                        Console.WriteLine();
                        break;
                }

                Console.WriteLine($"Name: {loggedUser.FirstName}\n" +
                                  $"Lastname: {loggedUser.LastName}\n" +
                                  $"Username: {loggedUser.Username}\n" +
                                  $"Account type: {loggedUser.AccountType}");
            }

            if(loggedTrainer != null)//if (CurrentSessionType == typeof(Trainer))
            {
                Console.WriteLine($"Name: {loggedTrainer.FirstName}\n" +
                                  $"Lastname: {loggedTrainer.LastName}\n" +
                                  $"Username: {loggedTrainer.Username}");
                Console.WriteLine($"List of people training: ");
                loggedTrainer.TrainedUsers
                    .Select(user => user.FirstName).ToList()
                    .ForEach(x => Console.WriteLine(x));
            }
        }

        #region Trainer Menu
        public void ShowTrainerMenu()
        {
            //Reschedule training, Account, Train and Log Out

            Console.WriteLine("1. Train.");
            Console.WriteLine("2. Account.");
            Console.WriteLine("3. Reschedule training.");
            Console.WriteLine("4. Log Out.");


            int option = ChooseAnOption(1, 3);
            //var user = CurrentSession.CurrentUser.GetType();
            _storage.BaseEntities.FirstOrDefault(x => x.Id == CurrentSession.CurrentTrainer.Id);
            switch (option)
            {
                case 1:
                    Train();
                    break;
                case 2:
                    Account();
                    break;
                case 3:
                    _trainerService.LogOut();
                    break;
            }
        }
        #endregion

        private int ChooseAnOption(int min, int max)
        {
            while (true)
            {
                Console.Write("Please choose an option: ");
                var input = Console.ReadLine();

                if (!int.TryParse(input, out int number))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong input, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (number >= min && number <= max)
                {
                    return number;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Wrong input, range: {min} - {max}, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
        }
        private void WriteLineInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
