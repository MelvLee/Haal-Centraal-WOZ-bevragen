using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class HuisnummerToevoegingSpecification : Specification<WozObjectHal>
{
    private readonly string _huisnummerToevoeging;

    public HuisnummerToevoegingSpecification(string huisnummerToevoeging)
    {
        _huisnummerToevoeging = huisnummerToevoeging;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.Aanduiding != null &&
                            wozObject.Aanduiding.Huisnummertoevoeging == _huisnummerToevoeging;
    }
}
