using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public class RecordingRepository(ApplicationDbContext context)
{
    public async Task<IEnumerable<Recording>> GetRecordingsByWork(int workId)
    {
        return await context.Recordings.Where(rec => rec.WorkId == workId).ToListAsync();
    }
}