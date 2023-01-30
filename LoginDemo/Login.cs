using DataLayer.Interfaces;
using StorageLayer.Interfaces;
using StorageLayer.Classes;

namespace LoginDemo
{
    public class Login
    {
        private ILoginDataSource? dataSource;

        public Login(ILoginDataSource _dataSource)
        {
            dataSource = _dataSource;
        }

        public void Run()
        {
            do
            {
                promptForName();
            } while (true);
        }

        private void promptForName()
        {
            Console.Write("Hi, what is your name? "); //Spec 1: Prompt for Name – Initial Flow: “Hi, what is your name ?
            string? userName = Console.ReadLine();

            IUserRecord? userRec = getUser(userName);
            int userID = userRec != null ? userRec.UserID : -1;

            if (userID != -1)
            {
                IEnumerable<UserPasswordData> pwList = getUserPasswords(userID);

                if (pwList.Count() == 0) //Spec 1.1:  If the name has no stored questions, present the Store flow
                {
                    storeFlow(userID);
                }
                else //Spec 1.2:  Else, asks if the user wants to answer a security question : “Do you want to answer a security question?”
                {
                    Console.Write("Do you want to answer a security question? ");
                    string? answerValue = Console.ReadLine();

                    if (!string.IsNullOrEmpty(answerValue) && answerValue.Trim().ToLower() == "yes") //Spec 1.2.1: If Yes, present the “Answer” flow
                    {
                        answerFlow(pwList);
                    }
                    else //Spec 1.2.2:  Else re-do answers through the “Store” flow
                    {
                        storeFlow(userID);
                    }
                }
            }
        }

        private UserData? getUser(string? _userName)
        {
            UserData? usrRec = null;

            if (dataSource != null)
            {
                Task<UserData?> usrData = dataSource.GetUser(_userName);

                usrRec = usrData.Result;
            }

            return usrRec;
        }

        private void storeFlow(int _usrID)
        {
            Console.Write("Would you like to store answers to security questions? "); //Spec 2: “Would you like to store answers to security questions?”
            string? storeAnswers = Console.ReadLine();

            if (!string.IsNullOrEmpty(storeAnswers) && storeAnswers.Trim().ToLower() == "yes") //Spec 2.1: If yes, loop through provided questions and prompt them for answers, storing the answers
            {
                UserPasswordList usrPwdList = new UserPasswordList();
                IEnumerable<QuestionData> questions = getQuestions();

                foreach (IQuestionRecord question in questions)
                {
                    Console.Write(question.Question + " ");
                    
                    UserPasswordData usrPwd = new UserPasswordData() { Answer = Console.ReadLine(), QuestionID = question.QuestionID, UserID = _usrID };

                    if (usrPwd.Valid())
                    {
                        usrPwdList.Add(usrPwd);
                    }
                }

                if (usrPwdList.Count() >= 3) //Spec 2.1.1 Out of 10 total questions the user has to choose 3.  
                {
                    Console.Write("Store New Answers? ");
                    string? answer = Console.ReadLine();

                    if (!string.IsNullOrEmpty(answer) && answer.Trim().ToLower() == "yes")  // Sped 2.2: Verify user declines to store
                    {
                        storeUserPasswords(usrPwdList);
                    }
                }
                else //Spec doesn't specify what to do if they don't have enough.  Assume abort
                {
                    Console.WriteLine("Failed to answer enough questions with valid answers.  Store aborted.");
                }
            }
        }

        private void answerFlow(IEnumerable<UserPasswordData> _passwords)
        {
            if (_passwords != null)
            {
                bool success = false;

                foreach (UserPasswordData userPassword in _passwords) //Spec 3: present questions until either the user runs out of questions or answers one correctly
                {
                    string question = getQuestion(userPassword.QuestionID);

                    if (!string.IsNullOrEmpty(question))
                    {
                        Console.Write(question + " ");
                        string? answer = Console.ReadLine();

                        if (!string.IsNullOrEmpty(answer) && answer == userPassword.Answer)
                        {
                            success = true;
                            break;
                        }
                    }
                }

                if (success) //Spec 3.1: If the user answers correctly, congratulate the user
                {
                    Console.WriteLine("Congrats on logging in");
                }
                else //Spec 3.2: If the user runs out of questions, let them know
                {
                    Console.WriteLine("Out of questions.  Could not verify.");
                }
            }
            //spec 3.3:  Go back to the Prompt for Name flow when finished
        }
        private void storeUserPasswords(UserPasswordList _usrPwdList)
        {
            if (dataSource != null)
            {
                dataSource.StoreUserPasswords(_usrPwdList);
            }
        }
        private string getQuestion(int _questionID)
        {
            string question = string.Empty;
            if (dataSource != null)
            {
                Task<QuestionData?> usrData = dataSource.GetQuestion(_questionID);

                question = (usrData.Result!=null && usrData.Result.Question != null)?usrData.Result.Question:string.Empty;
            }

            return question;
        }

        private IEnumerable<QuestionData> getQuestions()
        {
            IEnumerable<QuestionData> questions = new QuestionList();

            if (dataSource != null)
            {
                Task<IEnumerable<QuestionData>> questionData = dataSource.GetQuestions();

                questions = (questionData.Result != null && questionData.Result != null) ? questionData.Result : questions;
            }

            return questions;
        }

        private IEnumerable<UserPasswordData> getUserPasswords(int _userID)
        {
            IEnumerable<UserPasswordData> pwList = new UserPasswordList();

            if (dataSource != null)
            {
                Task<IEnumerable<UserPasswordData>> pwdData = dataSource.GetUserPasswords(_userID);

                pwList = pwdData.Result;
            }

            return pwList;
        }
    }
}