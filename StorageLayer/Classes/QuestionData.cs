using DataLayer.Interfaces;

namespace StorageLayer.Classes
{

    public class QuestionData : IQuestionRecord
    {
        private int questionID = -1;
        private string question = string.Empty;
        public int QuestionID 
        {
            get { return questionID; }
            set { questionID = value; }
        }
        public string? Question 
        {
            get { return question; }
            set { question = !string.IsNullOrWhiteSpace(value)?value.Trim():question; }
        }
    }
}
