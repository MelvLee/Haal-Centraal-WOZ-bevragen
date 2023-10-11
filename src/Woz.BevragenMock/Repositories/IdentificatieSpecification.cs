using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class IdentificatieSpecification : Specification<WozObjectHal>
{
    private readonly string _identificatie;

    public IdentificatieSpecification(string identificatie)
    {
        _identificatie = identificatie;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.Identificatie == _identificatie;
    }
}
