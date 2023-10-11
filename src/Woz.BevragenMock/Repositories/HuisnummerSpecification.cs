using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class HuisnummerSpecification : Specification<WozObjectHal>
{
    private readonly int _huisnummer;

    public HuisnummerSpecification(int huisnummer)
    {
        _huisnummer = huisnummer;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.Aanduiding != null &&
                            wozObject.Aanduiding.Huisnummer.HasValue &&
                            wozObject.Aanduiding.Huisnummer.Value == _huisnummer;
    }
}
