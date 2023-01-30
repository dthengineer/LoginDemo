using StorageLayer.Classes;

namespace StorageLayer.Interfaces
{
    public interface ILoginDataSource
    {
        public Task<UserData?> GetUser(string? _username);
        public Task<QuestionData?> GetQuestion(int _questionID);
        public Task<IEnumerable<QuestionData>> GetQuestions();
        public Task<IEnumerable<UserPasswordData>> GetUserPasswords(int _userID);
        public Task StoreUserPasswords(IEnumerable<UserPasswordData> _userPasswords);
    }
}
