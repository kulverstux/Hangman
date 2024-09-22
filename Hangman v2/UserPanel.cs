using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Hangman_v2
{
    public class UserPanel
    {
        public string userName { get; set; }
        public bool CheckIfUserIsLoggedIn()
        {
            if (GameParameters.UserSuccessfullyLoggedIn == true)
            {
                Console.WriteLine("Logged in");
                return true;
            }
            else
            {
                Console.WriteLine("Not logged in");
                return false;
            }
        }
        private void UserPanelHeadLineText(string userName)
        {
            Console.WriteLine("****************");
            Console.WriteLine("*  User panel  *");
            Console.WriteLine("****************");
            Console.WriteLine($"Welcome {userName}\n");    
        }
        private void UserPanelMenuText()
        {
            Console.WriteLine("1. Check personal info");
            Console.WriteLine("2. Check personal statistics");
            Console.WriteLine("3. Log out");
        }
        public void UserPanelController()
        {  
            Console.Clear();
            UserPanelHeadLineText(userName);
            UserPanelMenuText();
            UserPanelUserMenuSelected();          
        }
        private void UserPanelUserMenuSelected()
        {
            bool currentMenu = true;
            while (currentMenu)
            {
                Console.WriteLine("Select from the options above:");
                string userSelected = Console.ReadLine();
                switch (userSelected)
                {
                    case "1": 
                    {
                        CheckPersonalInfo();
                        currentMenu = false;
                        break;
                    }
                    case "2":
                    {
                        CheckPersonalStatistics(); //not done yet
                        currentMenu = false;
                        break; 
                    }
                    case "3":
                    {
                        GameParameters.UserSuccessfullyLoggedIn = false;
                        currentMenu = false;
                        Engine e = new();
                        e.LoginScreenSelection();
                        break;
                    }
                    default:
                    break;
                }
            }
        }
        private void CheckPersonalInfo()
        {
            using (var db = new MyDBContext())
            {
                var result = db.UserLogin.Where(a => a.UserName == userName).Select(s => new {s.Name, s.LastName, s.UserName});
                var resultArray = result.ToArray();

                foreach (var item in resultArray)
                {
                    Console.WriteLine($"Name:       {item.Name}");
                    Console.WriteLine($"Last name:  {item.LastName}");
                    Console.WriteLine($"Username:   {item.UserName}");
                }
                Console.WriteLine("\n Press any key to go back");
                Console.ReadKey();
                UserPanelController();
            }
        }
        private void CheckPersonalStatistics()
        {
            Console.WriteLine("So empty here...");
            Console.WriteLine("\n Press any key to go back");
            Console.ReadKey();
            UserPanelController();
        }
    }   
}
