using Arvato.DBAdapter.Entities;
using Arvato.DBAdapter.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Arvato.DBAdapter.Context
{
    class DataBaseContext : DbContext
    {
        //readonly static string config = @"Server=localhost,1433;Database=Arvato;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;";

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<CustomerSupport> CustomerSupports { get; set; }


        //This part was removed because the project is running in memory
        //If you need to run in Database this part needs to be descomented 

        //protected override void OnConfiguring(DbContextOptionsBuilder option)
        //    => option.UseSqlServer(config);

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CustumerSupportsMapp());
        //}

    }
}
