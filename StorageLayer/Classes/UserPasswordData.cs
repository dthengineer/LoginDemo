using DataLayer.Interfaces;

namespace StorageLayer.Classes
{
    public class UserPasswordData : IUserPasswordRecord
    {
        private int userID = -1;
        private int questionID = -1;
        private string answer = string.Empty;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
            
        public int QuestionID
        {
            get { return questionID; }
            set { questionID = value; }
        }
        public string? Answer
        {
            get { return answer; }
            set { answer = !string.IsNullOrWhiteSpace(value) ? value.Trim() : string.Empty; }
        }

        public bool Valid()
        {
            return userID != -1 && questionID != -1 && !string.IsNullOrWhiteSpace(answer);
        }
    }
}
