using StorageLayer.Classes;

namespace StorageLayer.Interfaces
{
    public interface ILoginDataSource
    {
        /// <summary>
        /// Returns a user record (user ID, User Name) based on user name
        /// </summary>
        /// <param name="_username">The record we wish to retrieve</param>
        /// <returns>returns null if name not found.  Otherwise user record</returns>
        public Task<UserData?> GetUser(string? _username);
        /// <summary>
        /// Get's a questions Data (Question ID/Prompt Text) based on the Question ID
        /// </summary>
        /// <param name="_questionID">The number of the question</param>
        /// <returns>null if ID not found.  Otherwise Question Record</returns>
        public Task<QuestionData?> GetQuestion(int _questionID);
        /// <summary>
        /// Retrieves all available security questions
        /// </summary>
        /// <returns>returns list of security questions</returns>
        public Task<IEnumerable<QuestionData>> GetQuestions();
        /// <summary>
        /// Returns a list of user passwords (Question ID, User ID, Answer) based on user ID
        /// </summary>
        /// <param name="_userID">The ID of the user we want passwords for</param>
        /// <returns>empty list if user ID questions not found.  Otherwise list of question IDs/answers</returns>
        public Task<IEnumerable<UserPasswordData>> GetUserPasswords(int _userID);
        /// <summary>
        /// Stores a list of passwords/Question ID pairs for a given user ID
        /// Clears out old questions
        /// </summary>
        /// <param name="_userPasswords">The list of questions IDs, User ID's and Answers</param>
        /// <returns>return nothing.  Just a Task</returns>
        public Task StoreUserPasswords(IEnumerable<UserPasswordData> _userPasswords);
    }
}
