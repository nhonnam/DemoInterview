using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoInterview.DbContexts
{
    public class AppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private const string CONNECTION_STRING = "Server=(localdb)\\MSSQLLocalDB;Database=DemoInterview;Trusted_Connection=True;";

        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(CONNECTION_STRING).Options;
            return new AppDbContext(options);
        }
    }
}
