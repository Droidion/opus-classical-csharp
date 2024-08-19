using FuzzySharp;
using OpusClassical.Models;
using OpusClassical.Repositories;

namespace OpusClassical.Services;

public interface IComposerSearchService
{
    IEnumerable<ComposerSearchResult> GetSearch(string input);
    Task RefreshCache();
}

public class ComposerSearchService(IComposerSearchRepository composerSearchRepo) : IComposerSearchService
{
    private IEnumerable<ComposerSearchResult> _composerSearchResults = [];

    private IEnumerable<string> Slugs => _composerSearchResults.Select(c => c.Slug);

    public IEnumerable<ComposerSearchResult> GetSearch(string input)
    {
        var foundIndexes = Process.ExtractTop(input, Slugs, limit: 5).Select(r => r.Index);
        var foundComposers = foundIndexes.Select(index => _composerSearchResults.ElementAt(index));
        return foundComposers;
    }

    public async Task RefreshCache()
    {
        _composerSearchResults = await composerSearchRepo.GetComposerSearchResults();
    }
}