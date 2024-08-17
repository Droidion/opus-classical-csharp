using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class ComposerSearchRepository(ApplicationDbContext context)
{
    public async Task<IEnumerable<ComposerSearchResult>> GetComposerSearchResults()
    {
        return await context.ComposerSearchResults.ToListAsync();
    }
}