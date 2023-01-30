using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using StorageLayer.Interfaces;

namespace StorageLayer.Classes
{
    public class LoginDatabase : ILoginDataSource
    {
        private readonly string connString;

        public LoginDatabase(string _connString)
        {
            connString = _connString;
        }
        private async Task<IEnumerable<T>> LoadData<T, U>(string _storedProcedure, U _parameters)
        {
            using IDbConnection connection = new SqlConnection(connString);

            return await connection.QueryAsync<T>(_storedProcedure, _parameters, commandType: CommandType.StoredProcedure);
        }

        private async Task SaveData<T>(string _storedProcedure, T _parameters)
        {
            using IDbConnection connection = new SqlConnection(connString);

            await connection.ExecuteAsync(_storedProcedure, _parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<QuestionData?> GetQuestion(int _questionID)
        {
            var results = await LoadData<QuestionData, dynamic>(_storedProcedure: "dbo.GetQuestion", new { questionID = _questionID });

            return results.FirstOrDefault();
        }
        public Task<IEnumerable<QuestionData>> GetQuestions() => LoadData<QuestionData, dynamic>(_storedProcedure: "dbo.GetQuestions", new { });

        public async Task<UserData?> GetUser(string? _username) 
        {
            var results = await LoadData<UserData, dynamic>(_storedProcedure: "dbo.GetUser", new { userName = _username });

            return results.FirstOrDefault();
        }

        public Task<IEnumerable<UserPasswordData>> GetUserPasswords(int _userID) => LoadData<UserPasswordData, dynamic>(_storedProcedure: "dbo.GetUserPasswords", new { userID = _userID});

        public async Task StoreUserPasswords(IEnumerable<UserPasswordData> _userPasswords)
        {
            if (_userPasswords.Count() > 0)
            {
                int userIdParam = _userPasswords.First().UserID;
                await SaveData(_storedProcedure: "dbo.DeleteUserPasswords", new { userID = userIdParam });
                foreach (UserPasswordData userPassword in _userPasswords)
                {
                    await SaveData(_storedProcedure: "dbo.AddUserPassword", new { userId = userPassword.UserID, questionId = userPassword.QuestionID, answer = userPassword.Answer });
                }
            }
        }
    }
}
