using Data.Domain.Entities;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
             Database.EnsureCreated();
        }

        public DbSet<Stock> Stocks { get; set; }
    }
}