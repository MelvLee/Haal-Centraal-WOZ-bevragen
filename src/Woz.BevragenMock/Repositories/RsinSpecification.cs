using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class RsinSpecification : Specification<WozObjectHal>
{
    private readonly string _rsin;

    public RsinSpecification(string rsin)
    {
        _rsin = rsin;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            ((wozObject.BelanghebbendeEigenaar != null &&
                            wozObject.BelanghebbendeEigenaar.Rsin == _rsin) ||
                            (wozObject.BelanghebbendeGebruiker != null &&
                            wozObject.BelanghebbendeGebruiker.Rsin == _rsin));
    }
}
