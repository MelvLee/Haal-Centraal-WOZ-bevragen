using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class AdresseerbaarObjectIdentificatieSpecification : Specification<WozObjectHal>
{
    private readonly string _adresseerbaarObjectIdentificatie;

    public AdresseerbaarObjectIdentificatieSpecification(string adresseerbaarObjectIdentificatie)
    {
        _adresseerbaarObjectIdentificatie = adresseerbaarObjectIdentificatie;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.AdresseerbaarObjectIdentificaties != null &&
                            wozObject.AdresseerbaarObjectIdentificaties.Contains(_adresseerbaarObjectIdentificatie);
    }
}
