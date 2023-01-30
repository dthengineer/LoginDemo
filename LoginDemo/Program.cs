using StorageLayer.Classes;
using System.Configuration;

namespace LoginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string defaultConnString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            Login login = new Login(new LoginDatabase(defaultConnString));
            login.Run();

        }
    }
}