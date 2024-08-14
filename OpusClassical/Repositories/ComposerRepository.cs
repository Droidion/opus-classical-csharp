using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class ComposerRepository(ApplicationDbContext context)
{
    public async Task<IEnumerable<Composer>> GetAllComposers()
    {
        return await context.Composers.ToListAsync();
    }

    public async Task<Composer?> GetComposerBySlug(string slug)
    {
        return await context.Composers.FirstOrDefaultAsync(c => c.Slug == slug);
    }
}