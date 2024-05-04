using DataAccess;
using Services.Implementations;
using Services.Interfaces;

namespace TryBeingFit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUIService uiService = new UIService();
            Storage storage = new Storage();

            uiService.Login();
            while (true)
            {
                uiService.ShowMenu();
                var users = storage.Users.GetAll();
                var trainers = storage.Trainers.GetAll();
            }
        }
    }
}
