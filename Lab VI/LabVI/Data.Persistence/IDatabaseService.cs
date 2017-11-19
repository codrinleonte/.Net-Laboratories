using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public interface IDatabaseService
    {
        DbSet<Stock> Stocks { get; set; }

        int SaveChanges();
    }
}