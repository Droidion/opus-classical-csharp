using Microsoft.EntityFrameworkCore;
using OpusClassical.Models;

namespace OpusClassical.Repositories;

public interface IRecordingRepository
{
    Task<IEnumerable<Recording>> GetRecordingsByWork(int workId);
}

public class RecordingRepository(ApplicationDbContext context) : IRecordingRepository
{
    public async Task<IEnumerable<Recording>> GetRecordingsByWork(int workId)
    {
        return await context.Recordings.Where(rec => rec.WorkId == workId).ToListAsync();
    }
}