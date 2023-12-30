namespace BusinessDelegate
{
    public interface ISecurityOperations
    {
        void Login(string username, string password);

        void Logout();
    }

    public class SecurityImplementation : ISecurityOperations
    {
        public void Login(string username, string password)
        {
            Console.WriteLine("Logged in.");
        }

        public void Logout()
        {
            Console.WriteLine("Logged out.");
        }
    }

    public interface IOnlineOperations
    {
        void SellingOnline();

        void BuyOnline();
    }

    public class OnlineImplementation : IOnlineOperations
    {
        public void BuyOnline()
        {
            Console.WriteLine("Bought done.");
        }

        public void SellingOnline()
        {
            Console.WriteLine("Selling done.");
        }
    }

    public class AppGetway
    {
        private readonly ISecurityOperations _securityOperations;
        private readonly IOnlineOperations _onlineOperations;

        public AppGetway()
        {
            _securityOperations = new SecurityImplementation();
            _onlineOperations = new OnlineImplementation();
        }

        public void Login(string username, string password)
        {
            _securityOperations.Login(username, password);
        }

        public void BuyOnline()
        {
            _onlineOperations.BuyOnline();
        }
    }
}
