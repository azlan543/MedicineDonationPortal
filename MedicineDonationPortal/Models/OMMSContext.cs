using Microsoft.EntityFrameworkCore;

namespace MedicineDonationPortal.Models
{
    public class OMMSContext : DbContext
    {
        public OMMSContext()
        {

        }
        public OMMSContext(DbContextOptions options):base(options)
        {


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("dbconn"));
        }

        public DbSet<UserMaster> Users { get; set; }

        public DbSet<LoginModel>? LoginModel { get; set; }

        public DbSet<NGOModel>? NGOModel { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        
        public DbSet<UserReg>? UserReg { get; set; }
        
        public DbSet<MedBuy> MedBuy { get; set; }

    }
}
