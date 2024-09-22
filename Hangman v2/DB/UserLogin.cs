using System.ComponentModel.DataAnnotations;
namespace Hangman_v2.DB
{
    
    public class Login
    {
        public int LoginID { get; set; }

        [MaxLength(GameParameters.maxUserNameLength)]
        public required string UserName { get; set; }

        [MaxLength(GameParameters.maxNameLength)]
        public required string Name { get; set; }

        [MaxLength(GameParameters.maxLastNameLength)]
        public required string LastName { get; set; }
        
        [MaxLength(GameParameters.maxPasswordLength)]
        public required string Password { get; set; }

    }
}