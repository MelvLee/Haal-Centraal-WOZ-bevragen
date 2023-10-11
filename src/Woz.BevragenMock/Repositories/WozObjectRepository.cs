using Newtonsoft.Json;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class WozObjectRepository
{
    private readonly IWebHostEnvironment _environment;

    public WozObjectRepository(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<WozObjectHalCollectie> Zoek(ZoekFilter zoekFilter)
    {
        var path = Path.Combine(_environment.ContentRootPath, "Data", "test-data.json");
        if(!File.Exists(path))
        {
            throw new FileNotFoundException($"invalid file: '{path}'");
        }

        var data = await File.ReadAllTextAsync(path);

        var retval = new WozObjectHalCollectie
        {
            _embedded = new WozObjectHalCollectieEmbedded
            {
                WozObjecten = JsonConvert.DeserializeObject<List<WozObjectHal>>(data)?
                    .AsQueryable().Where(zoekFilter.ToSpecification().ToExpression()).ToList()
            }
        };

        return retval;
    }

    public async Task<WozObjectHal?> Raadpleeg(string identificatie)
    {
        var path = Path.Combine(_environment.ContentRootPath, "Data", "test-data.json");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"invalid file: '{path}'");
        }

        var data = await File.ReadAllTextAsync(path);

        var retval = JsonConvert.DeserializeObject<List<WozObjectHal>>(data)?
                    .AsQueryable().Where(identificatie.ToSpecification().ToExpression()).ToList();

        return retval?.FirstOrDefault();
    }
}
