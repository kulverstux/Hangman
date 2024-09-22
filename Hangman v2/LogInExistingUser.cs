using Hangman_v2.DB;
namespace Hangman_v2
{
    public class LogInExistingUser
    {
        CheckUserInputExt checkInputExt = new();
        public void LoginUserScreen()
        {
            
            string providedUsername = "",
                   providedPassword = "";
            string anotherAttempt = "";
            Console.Clear();
            Console.WriteLine("***************");
            Console.WriteLine("* USER LOG IN *");
            Console.WriteLine("***************");
            
            while (checkInputExt.Checkinputs(providedUsername))
            {
                Console.Write("Username: ");
                providedUsername = Console.ReadLine();
            }

            while (checkInputExt.Checkinputs(providedPassword))
            {
                Console.Write("Password: ");
                providedPassword = Console.ReadLine();
            }

            while (anotherAttempt.ToLower() != "n")
            {
                if (!TryToLogIn(providedUsername, providedPassword))
                {
                    Console.WriteLine("Failed login attempt");
                    Console.WriteLine("Do you want to retry? Y [YES] N [No]");
                    anotherAttempt = Console.ReadLine();
                    if (anotherAttempt.ToLower() == "y")
                    {                       
                        LoginUserScreen();                                         
                    }
                    else
                    {
                        Engine e = new();
                        Console.Clear();
                        e.LoginScreenSelection();
                    }
                }
                else
                {
                    anotherAttempt = "n";
                    GameParameters.UserSuccessfullyLoggedIn = false;
                }
            }
        }
        private bool TryToLogIn(string usr, string pass)
        {
            using (var db = new MyDBContext())
            {
                var result = db.UserLogin.Where(a => a.UserName == usr && a.Password == pass);
                if (result.Any())
                {
                    GameParameters.UserSuccessfullyLoggedIn = true;
                    UserPanel u = new();
                    u.userName = usr;
                    u.UserPanelController();


                    return true;
                }
                else
                {

                    return false;
                }
            }
        }

    }  
    public class CheckUserInputExt : CheckUserInput
    {
        public bool Checkinputs(string userInput)
        {
            if (CheckUserInput.BasicChecks(userInput) || userInput.Length > GameParameters.maxUserNameLength)
                return false;

            return true;
        }
    }
}
