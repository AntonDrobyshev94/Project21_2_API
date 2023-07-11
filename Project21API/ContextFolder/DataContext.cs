using Microsoft.EntityFrameworkCore;
using Project21API.Models;

namespace Project21API.ContextFolder
{
    public class DataContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  DataBase=Project21API;
                  Trusted_Connection=True;");
        }
    }
}
