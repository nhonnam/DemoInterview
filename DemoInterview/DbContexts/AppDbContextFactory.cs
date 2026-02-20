using Microsoft.EntityFrameworkCore;

namespace DemoInterview.DbContexts
{
    public class AppDbContextFactory : IDbContextFactory<AppDbContext>
    {
        private readonly string _connectionString;

        public AppDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public AppDbContext CreateDbContext()
        {
            DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(_connectionString).Options;
            return new AppDbContext(options);
        }
    }
}
