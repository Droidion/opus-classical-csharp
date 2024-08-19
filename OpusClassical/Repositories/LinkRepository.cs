using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public interface ILinkRepository
{
    Task<IEnumerable<Link>> GetLinksByRecordings(IEnumerable<int> recordingIds);
}

public class LinkRepository(ApplicationDbContext context) : ILinkRepository
{
    public async Task<IEnumerable<Link>> GetLinksByRecordings(IEnumerable<int> recordingIds)
    {
        return await context.Links
            .Where(l => recordingIds.Contains(l.RecordingId))
            .ToListAsync();
    }
}