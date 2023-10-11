using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class NummeraanduidingIdentificatieSpecification : Specification<WozObjectHal>
{
    private readonly string _nummeraanduidingIdentificatie;

    public NummeraanduidingIdentificatieSpecification(string nummeraanduidingIdentificatie)
    {
        _nummeraanduidingIdentificatie = nummeraanduidingIdentificatie;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.Aanduiding != null &&
                            wozObject.Aanduiding.NummeraanduidingIdentificatie == _nummeraanduidingIdentificatie;
    }
}
