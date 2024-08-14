using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class PerformerRepository(ApplicationDbContext context)
{
    public async Task<IEnumerable<Performer>> GetPerformersByRecordings(IEnumerable<int> recordingIds)
    {
        return await context.Performers
            .Where(p => recordingIds.Contains(p.RecordingId))
            .ToListAsync();
    }
}