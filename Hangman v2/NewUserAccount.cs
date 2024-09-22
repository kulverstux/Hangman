using Hangman_v2.DB;
namespace Hangman_v2
{
    internal class NewUserAccount
    {
        public void NewUser()
        {
            using (var db = new MyDBContext())
            {
                bool untilGoodChoice = true;
                Console.Clear();
                while (untilGoodChoice)
                {
                    Console.WriteLine("*********************");
                    Console.WriteLine("* USERNAME CREATION *");
                    Console.WriteLine("*********************\n");
                    Console.Write("New username [max 10 symbols]: ");
                    string username = Console.ReadLine();
                    if (NewUserInfoInputCheck(username, GameParameters.maxUserNameLength))
                    {
                        var result = db.UserLogin.Where(a => a.UserName == username);
                        if (!result.Any())
                        {
                            
                            CreateANewUser(username);
                            untilGoodChoice = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Sorry, username is already taken. Please choose another one.");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter something for an username.");
                    }
                }
            }
        }
        private void CreateANewUser(string username)
        {
            string name = "",
                   lastName = "",
                   password = "";

            while (!NewUserInfoInputCheck(name, GameParameters.maxNameLength))
            {
                Console.Write($"Enter your name [max {GameParameters.maxNameLength} symbols]:");
                name = Console.ReadLine();
            }
            while (!NewUserInfoInputCheck(lastName, GameParameters.maxLastNameLength))
            { 
                Console.Write($"Enter your last name [max {GameParameters.maxLastNameLength} symbols]:");
                lastName = Console.ReadLine();
            }
            while (!NewUserInfoInputCheck(password, GameParameters.maxPasswordLength))
            {
                Console.Write($"Enter your password [max {GameParameters.maxLastNameLength} symbols]:");
                password = Console.ReadLine();
            }
            using (var db = new MyDBContext())
            {
                db.UserLogin.Add(new Login { UserName = username, Name = name, LastName = lastName, Password = password });
                db.SaveChanges();
                Console.WriteLine("Username successfully created.");
                Engine e = new();
                e.LoginScreenSelection();
            }
        }
        private bool NewUserInfoInputCheck(string entry, int length)
        {
            entry = entry.Trim();
            if ((entry != null && entry != "") && entry.Length <= length)
            {
                return true;
            }
            return false;
        }
    }
}
