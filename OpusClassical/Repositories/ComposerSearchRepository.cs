using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public interface IComposerSearchRepository
{
    Task<IEnumerable<ComposerSearchResult>> GetComposerSearchResults();
}

public class ComposerSearchRepository(ApplicationDbContext context) : IComposerSearchRepository
{
    public async Task<IEnumerable<ComposerSearchResult>> GetComposerSearchResults()
    {
        return await context.ComposerSearchResults.ToListAsync();
    }
}