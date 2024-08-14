using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class PeriodRepository(ApplicationDbContext context)
{
    public async Task<IEnumerable<Period>> GetAllPeriods()
    {
        return await context.Periods.ToListAsync();
    }
}