using Microsoft.EntityFrameworkCore;
using Model;

namespace Context
{
    public interface IDatabaseService
    {
        DbSet<Car> Cars { get; set; }
        int SaveChanges();
    }
}