using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace ZeyMer.Infrastructure.Data
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Local SQL Server bağlantı string'i
            optionsBuilder.UseSqlServer(
            "Data Source = SAMSA\\MSSQLSERVER01; Initial Catalog = ZeyMerDb; Integrated Security = True; Trust Server Certificate = True");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}