using Microsoft.EntityFrameworkCore;
using Model;

namespace Context
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}