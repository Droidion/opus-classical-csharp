using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public interface IWorkRepository
{
    Task<Work?> GetWorkById(int workId);
    Task<IEnumerable<Work>> GetWorksByComposerId(int composerId);
}

public class WorkRepository(ApplicationDbContext context) : IWorkRepository
{
    public async Task<Work?> GetWorkById(int workId)
    {
        return await context.Works.FirstOrDefaultAsync(w => w.Id == workId);
    }

    public async Task<IEnumerable<Work>> GetWorksByComposerId(int composerId)
    {
        return await context.Works.Where(w => w.ComposerId == composerId).ToListAsync();
    }
}