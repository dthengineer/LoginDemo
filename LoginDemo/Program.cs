using StorageLayer.Classes;
using System.Configuration;

namespace LoginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string defaultConnString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            //Below is a crude dependency injection sample.  It's not entity framework, but we aren't doing a full web app. 
            //But it employs SOLID principals allowing simple interfaces with substatution.  We could create another class here
            //That stores everything to disk, or whatever medium.  As long as it fulfills the ILoginDataSource Contract we are good.
            Login login = new Login(new LoginDatabase(defaultConnString));
            login.Run();

        }
    }
}