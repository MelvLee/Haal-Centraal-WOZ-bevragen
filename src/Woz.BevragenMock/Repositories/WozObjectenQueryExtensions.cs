using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public static class WozObjectenQueryExtensions
{
    public static Specification<WozObjectHal> ToSpecification(this ZoekFilter zoekFilter)
    {
        List<Specification<WozObjectHal>> specifications = new();

        if(!string.IsNullOrWhiteSpace(zoekFilter.AdresseerbaarObjectIdentificatie))
        {
            specifications.Add(new AdresseerbaarObjectIdentificatieSpecification(zoekFilter.AdresseerbaarObjectIdentificatie));
        }
        if (!string.IsNullOrWhiteSpace(zoekFilter.Rsin))
        {
            specifications.Add(new RsinSpecification(zoekFilter.Rsin));
        }
        if (!string.IsNullOrWhiteSpace(zoekFilter.KvkNummer))
        {
            specifications.Add(new KvkNummerSpecification(zoekFilter.KvkNummer));
        }
        if(!string.IsNullOrWhiteSpace(zoekFilter.NummeraanduidingIdentificatie))
        {
            specifications.Add(new NummeraanduidingIdentificatieSpecification(zoekFilter.NummeraanduidingIdentificatie));
        }
        if (!string.IsNullOrWhiteSpace(zoekFilter.Postcode))
        {
            specifications.Add(new PostcodeSpecification(zoekFilter.Postcode));
        }
        if (!string.IsNullOrWhiteSpace(zoekFilter.Huisnummer))
        {
            var huisnummer = int.Parse(zoekFilter.Huisnummer);
            specifications.Add(new HuisnummerSpecification(huisnummer));
        }
        if (!string.IsNullOrWhiteSpace(zoekFilter.Huisnummertoevoeging))
        {
            specifications.Add(new HuisnummerToevoegingSpecification(zoekFilter.Huisnummertoevoeging));
        }
        if (!string.IsNullOrWhiteSpace(zoekFilter.Huisletter))
        {
            specifications.Add(new HuisletterSpecification(zoekFilter.Huisletter));
        }

        Specification<WozObjectHal> retval = specifications[0];

        foreach (var spec in specifications.Skip(1))
        {
            retval = retval.And(spec);
        }

        return retval;
    }

    public static Specification<WozObjectHal> ToSpecification(this string identificatie)
    {
        return new IdentificatieSpecification(identificatie);
    }
}
