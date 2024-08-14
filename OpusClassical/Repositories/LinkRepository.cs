using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class LinkRepository(ApplicationDbContext context)
{
    public async Task<IEnumerable<Link>> GetLinksByRecordings(IEnumerable<int> recordingIds)
    {
        return await context.Links
            .Where(l => recordingIds.Contains(l.RecordingId))
            .ToListAsync();
    }
}