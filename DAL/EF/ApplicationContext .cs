using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.EF
{
    public class ApplicationContext : IdentityDbContext<User>

    {
        public readonly IConfiguration Configuration;

        //public DbSet<User> Users { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<Taska> Tasks { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
            //Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            string connectionString = "Server=(localdb)\\mssqllocaldb; Database=ScrumBoard;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
