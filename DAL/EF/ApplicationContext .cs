using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.EF
{
    public class ApplicationContext : DbContext
    {
        private IConfiguration configuration;

        public DbSet<User> Users { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public ApplicationContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Server=(localdb)\\mssqllocaldb; Database=ScrumBoard;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
