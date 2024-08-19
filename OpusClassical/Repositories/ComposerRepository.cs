using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public interface IComposerRepository
{
    Task<IEnumerable<Composer>> GetAllComposers();
    Task<Composer?> GetComposerBySlug(string slug);
}

public class ComposerRepository(ApplicationDbContext context) : IComposerRepository
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