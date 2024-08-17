using FuzzySharp;
using OpusClassical.Models;
using OpusClassical.Repositories;

namespace OpusClassical.Services;

public class ComposerSearchService(ComposerSearchRepository composerSearchRepo)
{
    private IEnumerable<ComposerSearchResult> _composerSearchResults = [];

    private IEnumerable<string> slugs => _composerSearchResults.Select(c => c.Slug);

    public IEnumerable<ComposerSearchResult> GetSearch(string input)
    {
        var foundIndexes = Process.ExtractTop(input, slugs, limit: 5).Select(r => r.Index);
        var foundComposers = foundIndexes.Select(index => _composerSearchResults.ElementAt(index));
        return foundComposers;
    }

    public async Task RefreshCache()
    {
        _composerSearchResults = await composerSearchRepo.GetComposerSearchResults();
    }
}