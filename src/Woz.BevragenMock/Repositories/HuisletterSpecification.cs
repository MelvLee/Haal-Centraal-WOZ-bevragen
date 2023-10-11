using System.Linq.Expressions;
using Woz.BevragenMock.Generated;

namespace Woz.BevragenMock.Repositories;

public class HuisletterSpecification : Specification<WozObjectHal>
{
    private readonly string _huisletter;

    public HuisletterSpecification(string huisletter)
    {
        _huisletter = huisletter;
    }

    public override Expression<Func<WozObjectHal, bool>> ToExpression()
    {
        return wozObject => wozObject != null &&
                            wozObject.Aanduiding != null &&
                            wozObject.Aanduiding.Huisletter == _huisletter;
    }
}
