using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class KvkNummerSpecification : Specification<WozObjectHal>
{
    private readonly string _kvkNummer;

    public KvkNummerSpecification(string kvkNummer)
    {
        _kvkNummer = kvkNummer;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            ((wozObject.BelanghebbendeEigenaar != null &&
                            wozObject.BelanghebbendeEigenaar.KvkNummer == _kvkNummer) ||
                            (wozObject.BelanghebbendeGebruiker != null &&
                            wozObject.BelanghebbendeGebruiker.KvkNummer == _kvkNummer));
    }
}
