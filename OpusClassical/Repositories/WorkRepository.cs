using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class WorkRepository(ApplicationDbContext context)
{
    public async Task<Work?> GetWorkBySlug(int workId)
    {
        return await context.Works.FirstOrDefaultAsync(w => w.Id == workId);
    }

    public async Task<IEnumerable<Work>> GetWorksByComposerId(int composerId)
    {
        return await context.Works.Where(w => w.ComposerId == composerId).ToListAsync();
    }
}