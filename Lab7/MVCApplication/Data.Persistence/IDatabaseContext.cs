
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<Stock> Stocks { get; set; }

        int SaveChanges();
    }
}