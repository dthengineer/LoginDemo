using DataLayer.Interfaces;


namespace StorageLayer.Classes
{

    public class UserData : IUserRecord 
    {
        public string? UserName
        {
            get { return userName; }
            set { userName = !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userName = string.Empty;
        private int userID = -1;

    }
}
