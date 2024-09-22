using Microsoft.EntityFrameworkCore;
using Hangman_v2.DB;
namespace Hangman_v2
{
    public class MyDBContext : DbContext
    {
        public DbSet<Login> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=MANTASPC\SQLEXPRESS;Database=HangmanDB;Trusted_Connection=True;TrustServerCertificate=True;ConnectRetryCount=0");
        }
    }
}