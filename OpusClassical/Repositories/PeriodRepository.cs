using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public interface IPeriodRepository
{
    Task<IEnumerable<Period>> GetAllPeriods();
}

public class PeriodRepository(ApplicationDbContext context) : IPeriodRepository
{
    public async Task<IEnumerable<Period>> GetAllPeriods()
    {
        return await context.Periods.ToListAsync();
    }
}