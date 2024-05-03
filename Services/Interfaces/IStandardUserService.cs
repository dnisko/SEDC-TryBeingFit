namespace Services.Interfaces
{
    public interface IStandardUserService : IPremiumUserService
    {
        /*
         Standard users should have a menu:
           
               Train, Upgrade to premium, Account and Log Out
           
                     
         */
        
        void Upgrade(int id);

    }
}
